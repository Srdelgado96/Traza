using Microsoft.AspNetCore.Identity;

namespace Traza.Web.Data;

public class ApplicationUser : IdentityUser
{
    public ApplicationUser()
    {
        LockoutEnabled = true;
    }

    public int? UsuarioId { get; set; }
    public string DisplayName { get; set; } = string.Empty;
    public string? ProfileImagePath { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime? LastLoginAt { get; set; }
}
