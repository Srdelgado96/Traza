namespace Traza.Web.Data.Entidades;

public class Proyecto
{
    public int Id { get; set; }
    public int Numero { get; set; }
    public DateTime FechaAlta { get; set; }
    public DateTime? FechaCierre { get; set; }
    public int? AreaId { get; set; }
    public int EstadoId { get; set; }
    public int PrioridadId { get; set; }
    public int? CoordinadorId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public DateTime ModificadoEn { get; set; }

    public AreaProyecto? Area { get; set; }
    public EstadoProyecto Estado { get; set; } = null!;
    public PrioridadProyecto Prioridad { get; set; } = null!;
    public Usuario? Coordinador { get; set; }

    public ICollection<ObjetivoProyecto> Objetivos { get; set; } = new List<ObjetivoProyecto>();
    public ICollection<FaseProyecto> Fases { get; set; } = new List<FaseProyecto>();
    public ICollection<DocumentoProyecto> Documentos { get; set; } = new List<DocumentoProyecto>();
    public ICollection<PresupuestoProyecto> Presupuestos { get; set; } = new List<PresupuestoProyecto>();
    public ICollection<ComentarioProyecto> Comentarios { get; set; } = new List<ComentarioProyecto>();
}

public class ObjetivoProyecto
{
    public int Id { get; set; }
    public int ProyectoId { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public int Orden { get; set; }

    public Proyecto Proyecto { get; set; } = null!;
}

public class FaseProyecto
{
    public int Id { get; set; }
    public int ProyectoId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int? ResponsableId { get; set; }
    public int EstadoId { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaObjetivo { get; set; }
    public DateTime? FechaReal { get; set; }

    public Proyecto Proyecto { get; set; } = null!;
    public Usuario? Responsable { get; set; }
    public EstadoFaseProyecto Estado { get; set; } = null!;
}

public class DocumentoProyecto
{
    public int Id { get; set; }
    public int ProyectoId { get; set; }
    public int TipoAdjuntoId { get; set; }
    public int UsuarioId { get; set; }
    public DateTime FechaDocumento { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public string NombreArchivo { get; set; } = string.Empty;
    public string? RutaArchivo { get; set; }

    public Proyecto Proyecto { get; set; } = null!;
    public TipoAdjunto TipoAdjunto { get; set; } = null!;
    public Usuario Usuario { get; set; } = null!;
}

public class PresupuestoProyecto
{
    public int Id { get; set; }
    public int ProyectoId { get; set; }
    public int UsuarioId { get; set; }
    public DateTime? FechaEstimacion { get; set; }
    public decimal ImporteEstimado { get; set; }
    public DateTime? FechaPresupuesto { get; set; }
    public decimal ImportePresupuestado { get; set; }
    public DateTime? FechaReal { get; set; }
    public decimal ImporteReal { get; set; }

    public Proyecto Proyecto { get; set; } = null!;
    public Usuario Usuario { get; set; } = null!;
}

public class ComentarioProyecto
{
    public int Id { get; set; }
    public int ProyectoId { get; set; }
    public int UsuarioId { get; set; }
    public DateTime Fecha { get; set; }
    public string Contenido { get; set; } = string.Empty;
    public bool EsSeguimiento { get; set; } = true;

    public Proyecto Proyecto { get; set; } = null!;
    public Usuario Usuario { get; set; } = null!;
}
