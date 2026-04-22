namespace Traza.Web.Services.Documents;

public static class DocumentStorageExtensions
{
    public static async Task InitializeDocumentStorageAsync(this IServiceProvider services)
    {
        await using var scope = services.CreateAsyncScope();
        var storage = scope.ServiceProvider.GetRequiredService<IDocumentStorageService>();
        await storage.EnsureReadyAsync();
    }
}
