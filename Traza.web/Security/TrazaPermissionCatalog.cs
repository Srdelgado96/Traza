namespace Traza.Web.Security;

public sealed record TrazaPermissionDefinition(string Key, string Name, string Description);

public static class TrazaPermissionCatalog
{
    public static readonly IReadOnlyList<TrazaPermissionDefinition> All =
    [
        new(TrazaPolicies.CanManageUsers, "Gestionar usuarios", "Alta, edicion, desactivacion y enlaces de activacion."),
        new(TrazaPolicies.CanManageCatalogs, "Gestionar tablas maestras", "Mantenimiento de catalogos y datos base."),
        new(TrazaPolicies.CanAccessProjects, "Ver proyectos", "Acceso a la pagina y consulta de proyectos."),
        new(TrazaPolicies.CanCreateIncidents, "Crear incidencias", "Alta de nuevas incidencias."),
        new(TrazaPolicies.CanEditIncidents, "Editar incidencias", "Apertura de incidencias en modo edicion."),
        new(TrazaPolicies.CanDeleteIncidents, "Eliminar incidencias", "Borrado de incidencias."),
        new(TrazaPolicies.CanCreateImprovementActions, "Crear acciones de mejora", "Alta de nuevas acciones de mejora."),
        new(TrazaPolicies.CanEditImprovementActions, "Editar acciones de mejora", "Apertura de acciones en modo edicion."),
        new(TrazaPolicies.CanDeleteImprovementActions, "Eliminar acciones de mejora", "Borrado de acciones de mejora."),
        new(TrazaPolicies.CanCreateProjects, "Crear proyectos", "Alta de nuevos proyectos."),
        new(TrazaPolicies.CanEditProjects, "Editar proyectos", "Apertura de proyectos en modo edicion."),
        new(TrazaPolicies.CanDeleteProjects, "Eliminar proyectos", "Borrado de proyectos."),
        new(TrazaPolicies.CanOpenCreationSelector, "Abrir selector de alta", "Acceso al boton Nueva gestion.")
    ];
}
