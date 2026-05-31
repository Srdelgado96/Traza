using Microsoft.EntityFrameworkCore;
using Traza.Web.Data.Entidades;
using Traza.Web.Security;

namespace Traza.Web.Data;

public static class ApplicationDbInitializer
{
    public static async Task InitializeDatabaseAsync(this IServiceProvider services)
    {
        await using var scope = services.CreateAsyncScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        await dbContext.Database.MigrateAsync();
        await EnsureApplicationUserSchemaAsync(dbContext);
        await EnsureRolesSchemaAsync(dbContext);
        await SeedAsync(dbContext);
    }

    private static async Task EnsureApplicationUserSchemaAsync(ApplicationDbContext dbContext)
    {
        await dbContext.Database.ExecuteSqlRawAsync(
            """
            IF COL_LENGTH(N'[AspNetUsers]', N'ProfileImagePath') IS NULL
            BEGIN
                ALTER TABLE [AspNetUsers] ADD [ProfileImagePath] NVARCHAR(500) NULL;
            END
            """);
    }

    private static async Task EnsureRolesSchemaAsync(ApplicationDbContext dbContext)
    {
        await dbContext.Database.ExecuteSqlRawAsync(
            """
            IF OBJECT_ID(N'[Roles]', N'U') IS NULL
            BEGIN
                CREATE TABLE [Roles](
                    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
                    [Nombre] NVARCHAR(100) NOT NULL,
                    [Descripcion] NVARCHAR(500) NULL,
                    [Activo] BIT NOT NULL CONSTRAINT [DF_Roles_Activo] DEFAULT(1)
                );

                CREATE UNIQUE INDEX [IX_Roles_Nombre] ON [Roles]([Nombre]);
            END
            """);

        await dbContext.Database.ExecuteSqlRawAsync(
            """
            IF OBJECT_ID(N'[UsuariosRol]', N'U') IS NULL
            BEGIN
                CREATE TABLE [UsuariosRol](
                    [UsuarioId] INT NOT NULL,
                    [RolId] INT NOT NULL,
                    CONSTRAINT [PK_UsuariosRol] PRIMARY KEY ([UsuarioId], [RolId]),
                    CONSTRAINT [FK_UsuariosRol_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuarios]([Id]) ON DELETE CASCADE,
                    CONSTRAINT [FK_UsuariosRol_Roles_RolId] FOREIGN KEY ([RolId]) REFERENCES [Roles]([Id]) ON DELETE CASCADE
                );

                CREATE INDEX [IX_UsuariosRol_RolId] ON [UsuariosRol]([RolId]);
            END
            """);

        await dbContext.Database.ExecuteSqlRawAsync(
            """
            IF OBJECT_ID(N'[RolesPermisos]', N'U') IS NULL
            BEGIN
                CREATE TABLE [RolesPermisos](
                    [RolId] INT NOT NULL,
                    [Permiso] NVARCHAR(100) NOT NULL,
                    CONSTRAINT [PK_RolesPermisos] PRIMARY KEY ([RolId], [Permiso]),
                    CONSTRAINT [FK_RolesPermisos_Roles_RolId] FOREIGN KEY ([RolId]) REFERENCES [Roles]([Id]) ON DELETE CASCADE
                );
            END
            """);
    }

    private static async Task SeedAsync(ApplicationDbContext dbContext)
    {
        await EnsureRoleAsync(dbContext, TrazaRoles.Administrador, "Acceso completo a la aplicacion.");
        await EnsureRoleAsync(dbContext, TrazaRoles.Supervisor, "Responsable de area con permisos de revision y coordinacion.");
        await EnsureRoleAsync(dbContext, TrazaRoles.Coordinador, "Gestion operativa de incidencias, acciones y proyectos.");
        await EnsureRoleAsync(dbContext, TrazaRoles.Usuario, "Alta de incidencias y acciones de mejora, con consulta general.");
        await EnsureRoleAsync(dbContext, TrazaRoles.Consulta, "Acceso de solo consulta.");
        await EnsureRoleAsync(dbContext, TrazaRoles.Calidad, "Gestion funcional de incidencias y acciones.");
        await EnsureRoleAsync(dbContext, TrazaRoles.Proyectos, "Seguimiento y coordinacion de proyectos.");
        await EnsureDefaultPermissionsAsync(dbContext);

        if (!await dbContext.UsuariosRol.AnyAsync())
        {
            var admin = await dbContext.Roles.FirstOrDefaultAsync(x => x.Nombre == TrazaRoles.Administrador);
            var calidad = await dbContext.Roles.FirstOrDefaultAsync(x => x.Nombre == TrazaRoles.Calidad);
            var proyectos = await dbContext.Roles.FirstOrDefaultAsync(x => x.Nombre == TrazaRoles.Proyectos);
            var consulta = await dbContext.Roles.FirstOrDefaultAsync(x => x.Nombre == TrazaRoles.Consulta);

            if (admin is not null && calidad is not null && proyectos is not null && consulta is not null)
            {
                dbContext.UsuariosRol.AddRange(
                [
                    new UsuarioRol { UsuarioId = 1, RolId = admin.Id },
                    new UsuarioRol { UsuarioId = 1, RolId = proyectos.Id },
                    new UsuarioRol { UsuarioId = 2, RolId = calidad.Id },
                    new UsuarioRol { UsuarioId = 3, RolId = consulta.Id },
                    new UsuarioRol { UsuarioId = 4, RolId = consulta.Id }
                ]);

                await dbContext.SaveChangesAsync();
            }
        }
    }

    private static async Task EnsureDefaultPermissionsAsync(ApplicationDbContext dbContext)
    {
        await EnsurePermissionsAsync(dbContext, TrazaRoles.Administrador, TrazaPermissionCatalog.All.Select(x => x.Key));
        await EnsurePermissionsAsync(dbContext, TrazaRoles.Supervisor,
        [
            TrazaPolicies.CanAccessProjects,
            TrazaPolicies.CanCreateIncidents,
            TrazaPolicies.CanEditIncidents,
            TrazaPolicies.CanDeleteIncidents,
            TrazaPolicies.CanCreateImprovementActions,
            TrazaPolicies.CanEditImprovementActions,
            TrazaPolicies.CanDeleteImprovementActions,
            TrazaPolicies.CanCreateProjects,
            TrazaPolicies.CanEditProjects,
            TrazaPolicies.CanDeleteProjects,
            TrazaPolicies.CanOpenCreationSelector
        ]);
        await EnsurePermissionsAsync(dbContext, TrazaRoles.Coordinador,
        [
            TrazaPolicies.CanAccessProjects,
            TrazaPolicies.CanCreateIncidents,
            TrazaPolicies.CanEditIncidents,
            TrazaPolicies.CanCreateImprovementActions,
            TrazaPolicies.CanEditImprovementActions,
            TrazaPolicies.CanCreateProjects,
            TrazaPolicies.CanEditProjects,
            TrazaPolicies.CanOpenCreationSelector
        ]);
        await EnsurePermissionsAsync(dbContext, TrazaRoles.Usuario,
        [
            TrazaPolicies.CanCreateIncidents,
            TrazaPolicies.CanCreateImprovementActions,
            TrazaPolicies.CanOpenCreationSelector
        ]);
        await EnsurePermissionsAsync(dbContext, TrazaRoles.Consulta,
        [
            TrazaPolicies.CanAccessProjects
        ]);
        await EnsurePermissionsAsync(dbContext, TrazaRoles.Calidad,
        [
            TrazaPolicies.CanCreateIncidents,
            TrazaPolicies.CanEditIncidents,
            TrazaPolicies.CanCreateImprovementActions,
            TrazaPolicies.CanEditImprovementActions,
            TrazaPolicies.CanOpenCreationSelector
        ]);
        await EnsurePermissionsAsync(dbContext, TrazaRoles.Proyectos,
        [
            TrazaPolicies.CanAccessProjects,
            TrazaPolicies.CanCreateProjects,
            TrazaPolicies.CanEditProjects,
            TrazaPolicies.CanOpenCreationSelector
        ]);
    }

    private static async Task EnsurePermissionsAsync(ApplicationDbContext dbContext, string roleName, IEnumerable<string> permissions)
    {
        var role = await dbContext.Roles.FirstOrDefaultAsync(x => x.Nombre == roleName);
        if (role is null)
        {
            return;
        }

        var existing = await dbContext.RolesPermisos
            .Where(x => x.RolId == role.Id)
            .Select(x => x.Permiso)
            .ToListAsync();

        var existingSet = existing.ToHashSet(StringComparer.OrdinalIgnoreCase);
        foreach (var permission in permissions.Where(x => !existingSet.Contains(x)))
        {
            dbContext.RolesPermisos.Add(new RolPermiso { RolId = role.Id, Permiso = permission });
        }

        await dbContext.SaveChangesAsync();
    }

    private static async Task EnsureRoleAsync(ApplicationDbContext dbContext, string nombre, string descripcion)
    {
        var role = await dbContext.Roles.FirstOrDefaultAsync(x => x.Nombre == nombre);
        if (role is null)
        {
            dbContext.Roles.Add(new Rol { Nombre = nombre, Descripcion = descripcion, Activo = true });
            await dbContext.SaveChangesAsync();
            return;
        }

        if (!role.Activo || string.IsNullOrWhiteSpace(role.Descripcion))
        {
            role.Activo = true;
            role.Descripcion = string.IsNullOrWhiteSpace(role.Descripcion) ? descripcion : role.Descripcion;
            await dbContext.SaveChangesAsync();
        }
    }
}
