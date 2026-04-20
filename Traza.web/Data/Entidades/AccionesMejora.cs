namespace Traza.Web.Data.Entidades;

public class AccionMejora
{
    public int Id { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaObjetivo { get; set; }
    public int SolicitanteId { get; set; }
    public int? CoordinadorId { get; set; }
    public int EstadoId { get; set; }
    public int? OrigenId { get; set; }
    public int? TipoAccionId { get; set; }
    public int? IncidenciaOrigenId { get; set; }
    public int? AccionMejoraPadreId { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public string? AccionInmediata { get; set; }
    public string? AnalisisCausas { get; set; }
    public string? PlanAccionPropuesto { get; set; }
    public bool Cerrada { get; set; }
    public DateTime? FechaCierre { get; set; }
    public string? EvaluacionCierre { get; set; }
    public DateTime ModificadaEn { get; set; }

    public Usuario Solicitante { get; set; } = null!;
    public Usuario? Coordinador { get; set; }
    public EstadoAccionMejora Estado { get; set; } = null!;
    public OrigenAccionMejora? Origen { get; set; }
    public TipoAccionMejora? TipoAccion { get; set; }
    public Incidencia? IncidenciaOrigen { get; set; }
    public AccionMejora? AccionMejoraPadre { get; set; }

    public ICollection<AccionMejora> AccionesHijas { get; set; } = new List<AccionMejora>();
    public ICollection<DocumentoAccionMejora> Documentos { get; set; } = new List<DocumentoAccionMejora>();
    public ICollection<TareaAccionMejora> Tareas { get; set; } = new List<TareaAccionMejora>();
    public ICollection<ComentarioAccionMejora> Comentarios { get; set; } = new List<ComentarioAccionMejora>();
}

public class DocumentoAccionMejora
{
    public int Id { get; set; }
    public int AccionMejoraId { get; set; }
    public int TipoAdjuntoId { get; set; }
    public int UsuarioId { get; set; }
    public DateTime FechaDocumento { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public string NombreArchivo { get; set; } = string.Empty;
    public string? RutaArchivo { get; set; }

    public AccionMejora AccionMejora { get; set; } = null!;
    public TipoAdjunto TipoAdjunto { get; set; } = null!;
    public Usuario Usuario { get; set; } = null!;
}

public class TareaAccionMejora
{
    public int Id { get; set; }
    public int AccionMejoraId { get; set; }
    public int UsuarioAsignadoId { get; set; }
    public string Tarea { get; set; } = string.Empty;
    public DateTime? FechaFinEsperada { get; set; }
    public bool EsUrgente { get; set; }
    public bool Cerrada { get; set; }
    public DateTime? FechaCierre { get; set; }

    public AccionMejora AccionMejora { get; set; } = null!;
    public Usuario UsuarioAsignado { get; set; } = null!;
}

public class ComentarioAccionMejora
{
    public int Id { get; set; }
    public int AccionMejoraId { get; set; }
    public int UsuarioId { get; set; }
    public DateTime Fecha { get; set; }
    public string Contenido { get; set; } = string.Empty;
    public bool EsSeguimiento { get; set; } = true;

    public AccionMejora AccionMejora { get; set; } = null!;
    public Usuario Usuario { get; set; } = null!;
}
