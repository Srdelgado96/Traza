using Radzen;
using Traza.Web.Components.Dialogs;

namespace Traza.Web.Services.AccionesMejora;

public sealed class AccionMejoraDialogCoordinator(DialogService dialogService)
{
    public event Func<Task>? AccionCreada;

    public async Task<bool> AbrirNuevaAsync()
    {
        var creada = await dialogService.OpenAsync<AccionMejoraCreacionDialog>(
            "Nueva accion de mejora",
            options: new DialogOptions { Width = "1180px", Height = "860px", CloseDialogOnOverlayClick = true });

        if (creada == true)
        {
            foreach (var callback in AccionCreada?.GetInvocationList() ?? [])
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
