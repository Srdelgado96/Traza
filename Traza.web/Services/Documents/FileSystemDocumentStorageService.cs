using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Options;
using Traza.Web.Configuration;

namespace Traza.Web.Services.Documents;

public class FileSystemDocumentStorageService : IDocumentStorageService
{
    private readonly IWebHostEnvironment environment;
    private readonly DocumentStorageOptions options;

    public FileSystemDocumentStorageService(IWebHostEnvironment environment, IOptions<DocumentStorageOptions> options)
    {
        this.environment = environment;
        this.options = options.Value;
    }

    public Task EnsureReadyAsync(CancellationToken cancellationToken = default)
    {
        var root = GetAbsoluteRootPath();
        Directory.CreateDirectory(root);

        var pruebaRuta = Path.Combine(root, $".write-test-{Guid.NewGuid():N}.tmp");
        using (File.Create(pruebaRuta))
        {
        }

        File.Delete(pruebaRuta);
        return Task.CompletedTask;
    }

    public async Task<StoredDocumentResult> SaveAsync(IBrowserFile file, string area, CancellationToken cancellationToken = default)
    {
        ValidarArchivo(file);

        var extension = Path.GetExtension(file.Name);
        var nombreGuardado = $"{Guid.NewGuid():N}{extension}";
        var directorioRelativo = Path.Combine(NormalizarSegmento(area), DateTime.UtcNow.ToString("yyyy"), DateTime.UtcNow.ToString("MM"));
        var directorioAbsoluto = Path.Combine(GetAbsoluteRootPath(), directorioRelativo);
        Directory.CreateDirectory(directorioAbsoluto);

        var rutaAbsoluta = Path.Combine(directorioAbsoluto, nombreGuardado);
        await using var origen = file.OpenReadStream(options.MaxFileSizeBytes, cancellationToken);
        await using var destino = File.Create(rutaAbsoluta);
        await origen.CopyToAsync(destino, cancellationToken);

        return new StoredDocumentResult
        {
            OriginalFileName = file.Name,
            RelativePath = Path.Combine(directorioRelativo, nombreGuardado).Replace('\\', '/')
        };
    }

    public Task DeleteAsync(string? relativePath, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(relativePath))
        {
            return Task.CompletedTask;
        }

        var rutaAbsoluta = ResolveAbsolutePath(relativePath);
        if (File.Exists(rutaAbsoluta))
        {
            File.Delete(rutaAbsoluta);
        }

        return Task.CompletedTask;
    }

    private void ValidarArchivo(IBrowserFile file)
    {
        if (file.Size <= 0)
        {
            throw new InvalidOperationException("El archivo seleccionado esta vacio.");
        }

        if (file.Size > options.MaxFileSizeBytes)
        {
            throw new InvalidOperationException($"El archivo supera el maximo permitido de {options.MaxFileSizeBytes / (1024 * 1024)} MB.");
        }

        var extension = Path.GetExtension(file.Name);
        if (string.IsNullOrWhiteSpace(extension) || !options.AllowedExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException("Tipo de archivo no permitido.");
        }
    }

    private string GetAbsoluteRootPath()
    {
        return Path.IsPathRooted(options.RootPath)
            ? options.RootPath
            : Path.Combine(environment.ContentRootPath, options.RootPath);
    }

    private string ResolveAbsolutePath(string relativePath)
    {
        var root = Path.GetFullPath(GetAbsoluteRootPath());
        var combined = Path.GetFullPath(Path.Combine(root, relativePath.Replace('/', Path.DirectorySeparatorChar)));
        if (!combined.StartsWith(root, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException("Ruta de documento no valida.");
        }

        return combined;
    }

    private static string NormalizarSegmento(string value)
    {
        return string.Concat(value.Select(ch => char.IsLetterOrDigit(ch) ? char.ToLowerInvariant(ch) : '-')).Trim('-');
    }
}
