namespace Traza.Web.Data.Entidades;

public class Departamento
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;

    public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    public ICollection<PersonalImplicadoIncidencia> PersonalImplicado { get; set; } = new List<PersonalImplicadoIncidencia>();
}

public class Proceso
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;

    public ICollection<TipologiaIncidencia> Tipologias { get; set; } = new List<TipologiaIncidencia>();
    public ICollection<Incidencia> Incidencias { get; set; } = new List<Incidencia>();
}

public class TipologiaIncidencia
{
    public int Id { get; set; }
    public int ProcesoId { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public bool Activa { get; set; } = true;

    public Proceso Proceso { get; set; } = null!;
    public ICollection<Incidencia> Incidencias { get; set; } = new List<Incidencia>();
}

public class EstadoIncidencia
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int Orden { get; set; }
    public bool EsCierre { get; set; }

    public ICollection<Incidencia> Incidencias { get; set; } = new List<Incidencia>();
}

public class EstadoDetalleIncidencia
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int Orden { get; set; }

    public ICollection<DetalleIncidencia> Detalles { get; set; } = new List<DetalleIncidencia>();
}

public class TipoDocumentoReferencia
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;

    public ICollection<DetalleIncidencia> DetallesIncidencia { get; set; } = new List<DetalleIncidencia>();
}

public class TipoAdjunto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;

    public ICollection<DocumentoIncidencia> DocumentosIncidencia { get; set; } = new List<DocumentoIncidencia>();
    public ICollection<DocumentoAccionMejora> DocumentosAccionMejora { get; set; } = new List<DocumentoAccionMejora>();
    public ICollection<DocumentoProyecto> DocumentosProyecto { get; set; } = new List<DocumentoProyecto>();
}

public class TipoCosteNoCalidad
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;

    public ICollection<CosteNoCalidadIncidencia> Costes { get; set; } = new List<CosteNoCalidadIncidencia>();
}

public class EstadoAccionMejora
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int Orden { get; set; }
    public bool EsCierre { get; set; }

    public ICollection<AccionMejora> Acciones { get; set; } = new List<AccionMejora>();
}

public class OrigenAccionMejora
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;

    public ICollection<AccionMejora> Acciones { get; set; } = new List<AccionMejora>();
}

public class TipoAccionMejora
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;

    public ICollection<AccionMejora> Acciones { get; set; } = new List<AccionMejora>();
}

public class AreaProyecto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;

    public ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
}

public class EstadoProyecto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int Orden { get; set; }
    public bool EsCierre { get; set; }

    public ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
}

public class PrioridadProyecto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int Orden { get; set; }

    public ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
}

public class EstadoFaseProyecto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int Orden { get; set; }
    public bool EsCierre { get; set; }

    public ICollection<FaseProyecto> Fases { get; set; } = new List<FaseProyecto>();
}

public class Rol
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public bool Activo { get; set; } = true;

    public ICollection<UsuarioRol> UsuariosRol { get; set; } = new List<UsuarioRol>();
}
