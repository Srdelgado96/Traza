using Microsoft.EntityFrameworkCore;

namespace Traza.Web.Data;

public static class ApplicationDbInitializer
{
    public static async Task InitializeDatabaseAsync(this IServiceProvider services)
    {
        await using var scope = services.CreateAsyncScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        await dbContext.Database.MigrateAsync();
        await SeedAsync(dbContext);
    }

    private static async Task SeedAsync(ApplicationDbContext dbContext)
    {
        // Reserved for catalog/lookup seed data once the domain model is added.
        await Task.CompletedTask;
    }
}
