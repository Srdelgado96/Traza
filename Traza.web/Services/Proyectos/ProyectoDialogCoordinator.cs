using Radzen;
using Traza.Web.Components.Dialogs;

namespace Traza.Web.Services.Proyectos;

public sealed class ProyectoDialogCoordinator(DialogService dialogService)
{
    public event Func<Task>? ProyectoCreado;

    public async Task<bool> AbrirNuevoAsync()
    {
        var creado = await dialogService.OpenAsync<ProyectoCreacionDialog>(
            "Nuevo proyecto",
            options: new DialogOptions { Width = "1180px", Height = "860px", CloseDialogOnOverlayClick = true });

        if (creado == true)
        {
            foreach (var callback in ProyectoCreado?.GetInvocationList() ?? [])
            {
                if (callback is Func<Task> taskCallback)
                {
                    await taskCallback();
                }
            }
        }

        return creado == true;
    }
}
