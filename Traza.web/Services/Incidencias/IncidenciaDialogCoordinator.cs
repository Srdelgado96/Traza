using Radzen;
using Traza.Web.Components.Dialogs;

namespace Traza.Web.Services.Incidencias;

public sealed class IncidenciaDialogCoordinator(DialogService dialogService)
{
    public event Func<Task>? IncidenciaCreada;

    public async Task<bool> AbrirNuevaAsync()
    {
        var creada = await dialogService.OpenAsync<IncidenciaCreacionDialog>(
            "Nueva incidencia",
            options: new DialogOptions { Width = "1180px", Height = "860px", CloseDialogOnOverlayClick = true });

        if (creada == true)
        {
            foreach (var callback in IncidenciaCreada?.GetInvocationList() ?? [])
            {
                if (callback is Func<Task> taskCallback)
                {
                    await taskCallback();
                }
            }
        }

        return creada == true;
    }
}
