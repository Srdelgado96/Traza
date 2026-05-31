using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Traza.Web.Data;

namespace Traza.Web.Security;

public sealed class TrazaClaimsPrincipalFactory(
    UserManager<ApplicationUser> userManager,
    IOptions<IdentityOptions> optionsAccessor,
    IDbContextFactory<ApplicationDbContext> dbContextFactory)
    : UserClaimsPrincipalFactory<ApplicationUser>(userManager, optionsAccessor)
{
    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
    {
        var identity = await base.GenerateClaimsAsync(user);

        if (!user.UsuarioId.HasValue)
        {
            return identity;
        }

        await using var db = await dbContextFactory.CreateDbContextAsync();
        var roles = await db.UsuariosRol
            .AsNoTracking()
            .Where(x => x.UsuarioId == user.UsuarioId.Value && x.Rol.Activo)
            .Select(x => x.Rol.Nombre)
            .ToListAsync();

        foreach (var role in roles.Where(x => !string.IsNullOrWhiteSpace(x)).Distinct(StringComparer.OrdinalIgnoreCase))
        {
            identity.AddClaim(new Claim(identity.RoleClaimType, role));
        }

        return identity;
    }
}
