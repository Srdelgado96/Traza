using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Authorization;
using Radzen;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using Traza.Web.Configuration;
using Traza.Web.Components;
using Traza.Web.Data;
using Traza.Web.Security;
using Traza.Web.Services.AccionesMejora;
using Traza.Web.Services.Documents;
using Traza.Web.Services.Incidencias;
using Traza.Web.Services.Proyectos;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException(
        "Connection string 'DefaultConnection' was not found. Configure it with User Secrets or environment variables.");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)
        .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));
builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IDbContextFactory<ApplicationDbContext>>().CreateDbContext());

builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddIdentityCookies();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "__Host-Traza.Auth";
    options.Cookie.HttpOnly = true;
    options.Cookie.Path = "/";
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.SameSite = SameSiteMode.Lax;
    options.LoginPath = "/login";
    options.LogoutPath = "/account/logout";
    options.AccessDeniedPath = "/login";
    options.SlidingExpiration = true;
});
builder.Services.AddAuthorization(options =>
{
    foreach (var permission in TrazaPermissionCatalog.All)
    {
        options.AddPolicy(permission.Key, policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.AddRequirements(new TrazaPermissionRequirement(permission.Key));
        });
    }
});
builder.Services.AddIdentityCore<ApplicationUser>(options =>
    {
        options.Password.RequiredLength = 10;
        options.Password.RequiredUniqueChars = 4;
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
        options.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();
builder.Services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, TrazaClaimsPrincipalFactory>();
builder.Services.AddScoped<IAuthorizationHandler, TrazaPermissionAuthorizationHandler>();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddRadzenComponents();
builder.Services.Configure<DocumentStorageOptions>(builder.Configuration.GetSection(DocumentStorageOptions.SectionName));
builder.Services.AddSingleton<IDocumentStorageService, FileSystemDocumentStorageService>();
builder.Services.AddScoped<IncidenciaDialogCoordinator>();
builder.Services.AddScoped<AccionMejoraDialogCoordinator>();
builder.Services.AddScoped<ProyectoDialogCoordinator>();

var app = builder.Build();

await app.Services.InitializeDatabaseAsync();
await app.Services.InitializeDocumentStorageAsync();

if (args is ["--reset-password", var userName])
{
    await ResetPasswordAndExitAsync(app.Services, userName);
    return;
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.Use(async (context, next) =>
{
    // Traza is private by default: every non-anonymous route must have a signed-in user.
    if (context.User.Identity?.IsAuthenticated == true || IsAnonymousPath(context.Request.Path))
    {
        await next();
        return;
    }

    context.Response.Redirect(QueryHelpers.AddQueryString("/login", "returnUrl", context.Request.GetEncodedPathAndQuery()));
});
app.UseAuthorization();
app.UseAntiforgery();

app.MapPost("/account/login", async (
    HttpContext httpContext,
    SignInManager<ApplicationUser> signInManager,
    UserManager<ApplicationUser> userManager,
    [AsParameters] LoginRequest request) =>
{
    if (string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
    {
        return Results.Redirect(BuildLoginRedirect("required", request.ReturnUrl));
    }

    var user = await userManager.FindByNameAsync(request.UserName.Trim());
    if (user is null || !user.IsActive)
    {
        return Results.Redirect(BuildLoginRedirect("invalid", request.ReturnUrl));
    }

    var result = await signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe == true, lockoutOnFailure: true);
    if (result.Succeeded)
    {
        user.LastLoginAt = DateTime.UtcNow;
        await userManager.UpdateAsync(user);
        var redirectUrl = IsLocalReturnUrl(request.ReturnUrl) ? request.ReturnUrl! : "/";
        return Results.Redirect(redirectUrl);
    }

    if (result.IsLockedOut)
    {
        return Results.Redirect(BuildLoginRedirect("locked", request.ReturnUrl));
    }

    return Results.Redirect(BuildLoginRedirect("invalid", request.ReturnUrl));
});

app.MapPost("/account/logout", async (SignInManager<ApplicationUser> signInManager) =>
{
    await signInManager.SignOutAsync();
    return Results.Redirect("/login");
});

app.MapPost("/account/set-password", async (
    SignInManager<ApplicationUser> signInManager,
    UserManager<ApplicationUser> userManager,
    [AsParameters] SetPasswordRequest request) =>
{
    if (string.IsNullOrWhiteSpace(request.UserId) ||
        string.IsNullOrWhiteSpace(request.Token) ||
        string.IsNullOrWhiteSpace(request.Password))
    {
        return Results.Redirect("/set-password?error=required");
    }

    if (request.Password != request.ConfirmPassword)
    {
        return Results.Redirect(BuildSetPasswordRedirect(request.UserId, request.Token, "mismatch"));
    }

    var user = await userManager.FindByIdAsync(request.UserId);
    if (user is null || !user.IsActive)
    {
        return Results.Redirect("/login?error=invalid");
    }

    var decodedToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.Token));
    var result = await userManager.ResetPasswordAsync(user, decodedToken, request.Password);

    if (!result.Succeeded)
    {
        return Results.Redirect(BuildSetPasswordRedirect(request.UserId, request.Token, "password"));
    }

    user.LastLoginAt = DateTime.UtcNow;
    await userManager.UpdateAsync(user);
    await signInManager.SignInAsync(user, isPersistent: false);
    return Results.Redirect("/");
});

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

static string BuildSetPasswordRedirect(string userId, string token, string error)
{
    var query = new Dictionary<string, string?>
    {
        ["userId"] = userId,
        ["token"] = token,
        ["error"] = error
    };

    return QueryHelpers.AddQueryString("/set-password", query);
}

static string BuildLoginRedirect(string error, string? returnUrl)
{
    var query = new Dictionary<string, string?>
    {
        ["error"] = error,
        ["returnUrl"] = IsLocalReturnUrl(returnUrl) ? returnUrl : null
    };

    return QueryHelpers.AddQueryString("/login", query);
}

static bool IsAnonymousPath(PathString path)
{
    if (!path.HasValue)
    {
        return true;
    }

    var value = path.Value;
    return value.Equals("/login", StringComparison.OrdinalIgnoreCase) ||
        value.Equals("/set-password", StringComparison.OrdinalIgnoreCase) ||
        value.Equals("/Error", StringComparison.OrdinalIgnoreCase) ||
        value.Equals("/account/login", StringComparison.OrdinalIgnoreCase) ||
        value.Equals("/account/set-password", StringComparison.OrdinalIgnoreCase) ||
        value.StartsWith("/_framework/", StringComparison.OrdinalIgnoreCase) ||
        value.StartsWith("/_content/", StringComparison.OrdinalIgnoreCase) ||
        value.StartsWith("/kaiadmin/", StringComparison.OrdinalIgnoreCase) ||
        value.StartsWith("/img/", StringComparison.OrdinalIgnoreCase) ||
        value.Equals("/app.css", StringComparison.OrdinalIgnoreCase) ||
        value.EndsWith(".css", StringComparison.OrdinalIgnoreCase) ||
        value.EndsWith(".js", StringComparison.OrdinalIgnoreCase) ||
        value.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
        value.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
        value.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
        value.EndsWith(".svg", StringComparison.OrdinalIgnoreCase) ||
        value.EndsWith(".ico", StringComparison.OrdinalIgnoreCase) ||
        value.EndsWith(".woff", StringComparison.OrdinalIgnoreCase) ||
        value.EndsWith(".woff2", StringComparison.OrdinalIgnoreCase) ||
        value.EndsWith(".ttf", StringComparison.OrdinalIgnoreCase) ||
        value.EndsWith(".eot", StringComparison.OrdinalIgnoreCase);
}

static bool IsLocalReturnUrl(string? returnUrl)
    => !string.IsNullOrWhiteSpace(returnUrl) &&
       returnUrl.StartsWith('/') &&
       !returnUrl.StartsWith("//") &&
       !returnUrl.StartsWith("/\\");

static async Task ResetPasswordAndExitAsync(IServiceProvider services, string userName)
{
    await using var scope = services.CreateAsyncScope();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var user = await userManager.FindByNameAsync(userName);
    var password = GenerateTemporaryPassword();

    if (user is null)
    {
        var usuario = await dbContext.Usuarios
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Login == userName);

        if (usuario is null)
        {
            Console.Error.WriteLine($"No se encontro el usuario '{userName}'.");
            Environment.ExitCode = 1;
            return;
        }

        user = new ApplicationUser
        {
            UserName = usuario.Login,
            Email = usuario.Email,
            EmailConfirmed = !string.IsNullOrWhiteSpace(usuario.Email),
            DisplayName = usuario.Nombre,
            IsActive = usuario.Activo,
            UsuarioId = usuario.Id
        };

        var createResult = await userManager.CreateAsync(user, password);
        if (!createResult.Succeeded)
        {
            Console.Error.WriteLine(string.Join(Environment.NewLine, createResult.Errors.Select(x => x.Description)));
            Environment.ExitCode = 1;
            return;
        }

        Console.WriteLine($"Usuario: {user.UserName}");
        Console.WriteLine($"Contrasena temporal: {password}");
        return;
    }

    var token = await userManager.GeneratePasswordResetTokenAsync(user);
    var result = await userManager.ResetPasswordAsync(user, token, password);
    if (!result.Succeeded)
    {
        Console.Error.WriteLine(string.Join(Environment.NewLine, result.Errors.Select(x => x.Description)));
        Environment.ExitCode = 1;
        return;
    }

    await userManager.SetLockoutEndDateAsync(user, null);
    await userManager.ResetAccessFailedCountAsync(user);

    Console.WriteLine($"Usuario: {user.UserName}");
    Console.WriteLine($"Contrasena temporal: {password}");
}

static string GenerateTemporaryPassword()
{
    const string lower = "abcdefghijkmnopqrstuvwxyz";
    const string upper = "ABCDEFGHJKLMNPQRSTUVWXYZ";
    const string digits = "23456789";
    const string symbols = "!@$%*?";
    const string all = lower + upper + digits + symbols;

    Span<char> password = stackalloc char[16];
    password[0] = lower[RandomNumberGenerator.GetInt32(lower.Length)];
    password[1] = upper[RandomNumberGenerator.GetInt32(upper.Length)];
    password[2] = digits[RandomNumberGenerator.GetInt32(digits.Length)];
    password[3] = symbols[RandomNumberGenerator.GetInt32(symbols.Length)];

    for (var i = 4; i < password.Length; i++)
    {
        password[i] = all[RandomNumberGenerator.GetInt32(all.Length)];
    }

    RandomNumberGenerator.Shuffle(password);
    return new string(password);
}

public sealed class LoginRequest
{
    [FromForm(Name = "userName")]
    public string UserName { get; set; } = string.Empty;

    [FromForm(Name = "password")]
    public string Password { get; set; } = string.Empty;

    [FromForm(Name = "rememberMe")]
    public bool? RememberMe { get; set; }

    [FromForm(Name = "returnUrl")]
    public string? ReturnUrl { get; set; }
}

public sealed class SetPasswordRequest
{
    [FromForm(Name = "userId")]
    public string UserId { get; set; } = string.Empty;

    [FromForm(Name = "token")]
    public string Token { get; set; } = string.Empty;

    [FromForm(Name = "password")]
    public string Password { get; set; } = string.Empty;

    [FromForm(Name = "confirmPassword")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
