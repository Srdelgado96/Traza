using Microsoft.AspNetCore.Components.Forms;

namespace Traza.Web.Services.Documents;

public interface IDocumentStorageService
{
    Task EnsureReadyAsync(CancellationToken cancellationToken = default);
    Task<StoredDocumentResult> SaveAsync(IBrowserFile file, string area, CancellationToken cancellationToken = default);
    Task DeleteAsync(string? relativePath, CancellationToken cancellationToken = default);
}
