using Microsoft.AspNetCore.Components.Forms;

namespace Traza.Web.Components.Models;

public class CatalogoSimpleFormModel
{
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public int? Orden { get; set; }
    public bool EsCierre { get; set; }
    public bool Activo { get; set; } = true;
}

public class TipologiaFormModel
{
    public int? ProcesoId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public bool Activa { get; set; } = true;
}

public class IncidenciaCreacionFormModel
{
    public DateTime FechaCreacion { get; set; } = DateTime.Today;
    public int? DetectorId { get; set; }
    public int? CoordinadorId { get; set; }
    public int? ProcesoId { get; set; }
    public int? TipologiaId { get; set; }
    public int? EstadoId { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public string? AccionInmediata { get; set; }
    public bool GeneraAccionMejora { get; set; }
    public List<DetalleIncidenciaFormModel> Detalles { get; set; } = [];
    public List<TareaIncidenciaFormModel> Tareas { get; set; } = [];
    public List<ComentarioIncidenciaFormModel> Comentarios { get; set; } = [];
    public List<DocumentoIncidenciaFormModel> Documentos { get; set; } = [];
}

public class AccionMejoraCreacionFormModel
{
    public DateTime FechaCreacion { get; set; } = DateTime.Today;
    public DateTime? FechaObjetivo { get; set; }
    public int? SolicitanteId { get; set; }
    public int? CoordinadorId { get; set; }
    public int? EstadoId { get; set; }
    public int? OrigenId { get; set; }
    public int? TipoAccionId { get; set; }
    public int? IncidenciaOrigenId { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public string? AccionInmediata { get; set; }
    public List<TareaAccionMejoraFormModel> Tareas { get; set; } = [];
    public List<ComentarioAccionMejoraFormModel> Comentarios { get; set; } = [];
    public List<DocumentoAccionMejoraFormModel> Documentos { get; set; } = [];
}

public class ProyectoCreacionFormModel
{
    public int? Numero { get; set; }
    public DateTime FechaAlta { get; set; } = DateTime.Today;
    public int? AreaId { get; set; }
    public int? EstadoId { get; set; }
    public int? PrioridadId { get; set; }
    public int? CoordinadorId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public List<ObjetivoProyectoFormModel> Objetivos { get; set; } = [];
    public List<FaseProyectoFormModel> Fases { get; set; } = [];
    public List<PresupuestoProyectoFormModel> Presupuestos { get; set; } = [];
    public List<ComentarioProyectoFormModel> Comentarios { get; set; } = [];
}

public class DetalleIncidenciaFormModel
{
    public string? Referencia { get; set; }
    public string? Lote { get; set; }
    public decimal? Cantidad { get; set; }
    public int? EstadoId { get; set; }
    public string? Descripcion { get; set; }
    public string? ClienteProveedor { get; set; }
    public string? DocumentoReferencia { get; set; }
    public int? TipoDocumentoId { get; set; }
}

public class TareaIncidenciaFormModel
{
    public int? UsuarioAsignadoId { get; set; }
    public string Tarea { get; set; } = string.Empty;
    public DateTime? FechaFinEsperada { get; set; }
    public bool EsUrgente { get; set; }
}

public class ComentarioIncidenciaFormModel
{
    public int? UsuarioId { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public string Contenido { get; set; } = string.Empty;
    public bool EsSeguimiento { get; set; } = true;
}

public class DocumentoIncidenciaFormModel
{
    public int? TipoAdjuntoId { get; set; }
    public int? UsuarioId { get; set; }
    public DateTime FechaDocumento { get; set; } = DateTime.Today;
    public string Titulo { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public string NombreArchivo { get; set; } = string.Empty;
    public IBrowserFile? Archivo { get; set; }
}

public class TareaAccionMejoraFormModel
{
    public int? UsuarioAsignadoId { get; set; }
    public string Tarea { get; set; } = string.Empty;
    public DateTime? FechaFinEsperada { get; set; }
    public bool EsUrgente { get; set; }
}

public class ComentarioAccionMejoraFormModel
{
    public int? UsuarioId { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public string Contenido { get; set; } = string.Empty;
    public bool EsSeguimiento { get; set; } = true;
}

public class DocumentoAccionMejoraFormModel
{
    public int? TipoAdjuntoId { get; set; }
    public int? UsuarioId { get; set; }
    public DateTime FechaDocumento { get; set; } = DateTime.Today;
    public string Titulo { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public string NombreArchivo { get; set; } = string.Empty;
    public IBrowserFile? Archivo { get; set; }
}

public class ObjetivoProyectoFormModel
{
    public int? Orden { get; set; }
    public string Descripcion { get; set; } = string.Empty;
}

public class FaseProyectoFormModel
{
    public string Nombre { get; set; } = string.Empty;
    public int? ResponsableId { get; set; }
    public int? EstadoId { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaObjetivo { get; set; }
}

public class PresupuestoProyectoFormModel
{
    public int? UsuarioId { get; set; }
    public DateTime? FechaEstimacion { get; set; }
    public decimal? ImporteEstimado { get; set; }
    public DateTime? FechaPresupuesto { get; set; }
    public decimal? ImportePresupuestado { get; set; }
    public DateTime? FechaReal { get; set; }
    public decimal? ImporteReal { get; set; }
}

public class ComentarioProyectoFormModel
{
    public int? UsuarioId { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public string Contenido { get; set; } = string.Empty;
    public bool EsSeguimiento { get; set; } = true;
}

public class UsuarioEdicionFormModel
{
    public int Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Genero { get; set; }
    public int? SupervisorId { get; set; }
    public int? DepartamentoId { get; set; }
    public bool Activo { get; set; } = true;
    public List<int> RolesSeleccionados { get; set; } = [];
}
