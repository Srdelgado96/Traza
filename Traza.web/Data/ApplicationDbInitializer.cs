using Microsoft.EntityFrameworkCore;
using Traza.Web.Data.Entidades;

namespace Traza.Web.Data;

public static class ApplicationDbInitializer
{
    public static async Task InitializeDatabaseAsync(this IServiceProvider services)
    {
        await using var scope = services.CreateAsyncScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        await dbContext.Database.MigrateAsync();
        await EnsureRolesSchemaAsync(dbContext);
        await SeedAsync(dbContext);
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
    }

    private static async Task SeedAsync(ApplicationDbContext dbContext)
    {
        if (!await dbContext.Roles.AnyAsync())
        {
            dbContext.Roles.AddRange(
            [
                new Rol { Nombre = "Administrador", Descripcion = "Acceso completo a la aplicacion.", Activo = true },
                new Rol { Nombre = "Calidad", Descripcion = "Gestion funcional de incidencias y acciones.", Activo = true },
                new Rol { Nombre = "Proyectos", Descripcion = "Seguimiento y coordinacion de proyectos.", Activo = true },
                new Rol { Nombre = "Consulta", Descripcion = "Acceso de solo consulta.", Activo = true }
            ]);

            await dbContext.SaveChangesAsync();
        }

        if (!await dbContext.UsuariosRol.AnyAsync())
        {
            var admin = await dbContext.Roles.FirstOrDefaultAsync(x => x.Nombre == "Administrador");
            var calidad = await dbContext.Roles.FirstOrDefaultAsync(x => x.Nombre == "Calidad");
            var proyectos = await dbContext.Roles.FirstOrDefaultAsync(x => x.Nombre == "Proyectos");
            var consulta = await dbContext.Roles.FirstOrDefaultAsync(x => x.Nombre == "Consulta");

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
}
