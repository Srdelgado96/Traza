namespace Traza.Web.Components.Models;

public class CatalogoSimpleFormModel
{
    public string Nombre { get; set; } = string.Empty;
    public int? Orden { get; set; }
    public bool EsCierre { get; set; }
}

public class TipologiaFormModel
{
    public int? ProcesoId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public bool Activa { get; set; } = true;
}
