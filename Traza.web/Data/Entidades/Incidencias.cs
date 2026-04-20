namespace Traza.Web.Data.Entidades;

public class Incidencia
{
    public int Id { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaGestion { get; set; }
    public int DetectorId { get; set; }
    public int? CoordinadorId { get; set; }
    public int ProcesoId { get; set; }
    public int? TipologiaId { get; set; }
    public int EstadoId { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public string? AccionCorrectiva { get; set; }
    public string? AccionInmediata { get; set; }
    public bool Cerrada { get; set; }
    public DateTime? FechaCierre { get; set; }
    public string? EvaluacionCierre { get; set; }
    public bool GeneraAccionMejora { get; set; }
    public int? AccionMejoraHijaId { get; set; }
    public DateTime ModificadaEn { get; set; }

    public Usuario Detector { get; set; } = null!;
    public Usuario? Coordinador { get; set; }
    public Proceso Proceso { get; set; } = null!;
    public TipologiaIncidencia? Tipologia { get; set; }
    public EstadoIncidencia Estado { get; set; } = null!;
    public AccionMejora? AccionMejoraHija { get; set; }

    public ICollection<DetalleIncidencia> Detalles { get; set; } = new List<DetalleIncidencia>();
    public ICollection<DocumentoIncidencia> Documentos { get; set; } = new List<DocumentoIncidencia>();
    public ICollection<TareaIncidencia> Tareas { get; set; } = new List<TareaIncidencia>();
    public ICollection<CosteNoCalidadIncidencia> CostesNoCalidad { get; set; } = new List<CosteNoCalidadIncidencia>();
    public ICollection<PersonalImplicadoIncidencia> PersonalImplicado { get; set; } = new List<PersonalImplicadoIncidencia>();
    public ICollection<ComentarioIncidencia> Comentarios { get; set; } = new List<ComentarioIncidencia>();
    public ICollection<AccionMejora> AccionesMejoraOrigen { get; set; } = new List<AccionMejora>();
}

public class DetalleIncidencia
{
    public int Id { get; set; }
    public int IncidenciaId { get; set; }
    public string? Referencia { get; set; }
    public string? Lote { get; set; }
    public decimal Cantidad { get; set; }
    public int EstadoId { get; set; }
    public string? Descripcion { get; set; }
    public string? ClienteProveedor { get; set; }
    public string? Codigo { get; set; }
    public string? NombreIc { get; set; }
    public int? TipoDocumentoId { get; set; }
    public string? DocumentoReferencia { get; set; }
    public string? Comentarios { get; set; }

    public Incidencia Incidencia { get; set; } = null!;
    public EstadoDetalleIncidencia Estado { get; set; } = null!;
    public TipoDocumentoReferencia? TipoDocumento { get; set; }
}

public class DocumentoIncidencia
{
    public int Id { get; set; }
    public int IncidenciaId { get; set; }
    public int TipoAdjuntoId { get; set; }
    public int UsuarioId { get; set; }
    public DateTime FechaDocumento { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public string NombreArchivo { get; set; } = string.Empty;
    public string? RutaArchivo { get; set; }

    public Incidencia Incidencia { get; set; } = null!;
    public TipoAdjunto TipoAdjunto { get; set; } = null!;
    public Usuario Usuario { get; set; } = null!;
}

public class TareaIncidencia
{
    public int Id { get; set; }
    public int IncidenciaId { get; set; }
    public int UsuarioAsignadoId { get; set; }
    public string Tarea { get; set; } = string.Empty;
    public DateTime? FechaFinEsperada { get; set; }
    public bool EsUrgente { get; set; }
    public bool Cerrada { get; set; }
    public DateTime? FechaCierre { get; set; }

    public Incidencia Incidencia { get; set; } = null!;
    public Usuario UsuarioAsignado { get; set; } = null!;
}

public class CosteNoCalidadIncidencia
{
    public int Id { get; set; }
    public int IncidenciaId { get; set; }
    public int UsuarioId { get; set; }
    public DateTime Fecha { get; set; }
    public int TipoCosteId { get; set; }
    public string? Observaciones { get; set; }
    public decimal Importe { get; set; }

    public Incidencia Incidencia { get; set; } = null!;
    public Usuario Usuario { get; set; } = null!;
    public TipoCosteNoCalidad TipoCoste { get; set; } = null!;
}

public class PersonalImplicadoIncidencia
{
    public int Id { get; set; }
    public int IncidenciaId { get; set; }
    public int UsuarioId { get; set; }
    public int? DepartamentoId { get; set; }
    public string? Notas { get; set; }

    public Incidencia Incidencia { get; set; } = null!;
    public Usuario Usuario { get; set; } = null!;
    public Departamento? Departamento { get; set; }
}

public class ComentarioIncidencia
{
    public int Id { get; set; }
    public int IncidenciaId { get; set; }
    public int UsuarioId { get; set; }
    public DateTime Fecha { get; set; }
    public string Contenido { get; set; } = string.Empty;
    public bool EsSeguimiento { get; set; } = true;

    public Incidencia Incidencia { get; set; } = null!;
    public Usuario Usuario { get; set; } = null!;
}
