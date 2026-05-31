namespace Traza.Web.Security;

public static class TrazaRoles
{
    public const string Administrador = "Administrador";
    public const string Supervisor = "Supervisor";
    public const string Coordinador = "Coordinador";
    public const string Usuario = "Usuario";
    public const string Consulta = "Consulta";

    // Legacy functional roles kept for compatibility with existing data.
    public const string Calidad = "Calidad";
    public const string Proyectos = "Proyectos";
}
