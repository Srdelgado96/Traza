using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Traza.Web.Data;

namespace Traza.Web.Security;

public sealed class TrazaPermissionRequirement(string permission) : IAuthorizationRequirement
{
    public string Permission { get; } = permission;
}

public sealed class TrazaPermissionAuthorizationHandler(IDbContextFactory<ApplicationDbContext> dbContextFactory)
    : AuthorizationHandler<TrazaPermissionRequirement>
{
    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        TrazaPermissionRequirement requirement)
    {
        if (context.User.Identity?.IsAuthenticated != true)
        {
            return;
        }

        if (context.User.IsInRole(TrazaRoles.Administrador))
        {
            context.Succeed(requirement);
            return;
        }

        var roleClaimType = context.User.Identities.FirstOrDefault(x => x.IsAuthenticated)?.RoleClaimType
            ?? System.Security.Claims.ClaimTypes.Role;
        var roleNames = context.User.Claims
            .Where(x => x.Type == roleClaimType)
            .Select(x => x.Value)
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();

        if (roleNames.Count == 0)
        {
            return;
        }

        await using var db = await dbContextFactory.CreateDbContextAsync();
        var hasPermission = await db.RolesPermisos
            .AsNoTracking()
            .AnyAsync(x => x.Permiso == requirement.Permission &&
                x.Rol.Activo &&
                roleNames.Contains(x.Rol.Nombre));

        if (hasPermission)
        {
            context.Succeed(requirement);
        }
    }
}
