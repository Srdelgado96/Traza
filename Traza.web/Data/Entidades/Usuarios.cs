namespace Traza.Web.Data.Entidades;

public class Usuario
{
    public int Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Genero { get; set; }
    public int? SupervisorId { get; set; }
    public int? DepartamentoId { get; set; }
    public bool Activo { get; set; } = true;

    public Usuario? Supervisor { get; set; }
    public Departamento? Departamento { get; set; }

    public ICollection<Usuario> Colaboradores { get; set; } = new List<Usuario>();
    public ICollection<UsuarioRol> RolesAsignados { get; set; } = new List<UsuarioRol>();
    public ICollection<Incidencia> IncidenciasDetectadas { get; set; } = new List<Incidencia>();
    public ICollection<Incidencia> IncidenciasCoordinadas { get; set; } = new List<Incidencia>();
    public ICollection<DocumentoIncidencia> DocumentosIncidencia { get; set; } = new List<DocumentoIncidencia>();
    public ICollection<TareaIncidencia> TareasIncidencia { get; set; } = new List<TareaIncidencia>();
    public ICollection<CosteNoCalidadIncidencia> CostesNoCalidad { get; set; } = new List<CosteNoCalidadIncidencia>();
    public ICollection<PersonalImplicadoIncidencia> IncidenciasPersonalImplicado { get; set; } = new List<PersonalImplicadoIncidencia>();
    public ICollection<ComentarioIncidencia> ComentariosIncidencia { get; set; } = new List<ComentarioIncidencia>();
    public ICollection<AccionMejora> AccionesMejoraSolicitadas { get; set; } = new List<AccionMejora>();
    public ICollection<AccionMejora> AccionesMejoraCoordinadas { get; set; } = new List<AccionMejora>();
    public ICollection<DocumentoAccionMejora> DocumentosAccionMejora { get; set; } = new List<DocumentoAccionMejora>();
    public ICollection<TareaAccionMejora> TareasAccionMejora { get; set; } = new List<TareaAccionMejora>();
    public ICollection<ComentarioAccionMejora> ComentariosAccionMejora { get; set; } = new List<ComentarioAccionMejora>();
    public ICollection<Proyecto> ProyectosCoordinados { get; set; } = new List<Proyecto>();
    public ICollection<FaseProyecto> FasesProyectoResponsable { get; set; } = new List<FaseProyecto>();
    public ICollection<DocumentoProyecto> DocumentosProyecto { get; set; } = new List<DocumentoProyecto>();
    public ICollection<PresupuestoProyecto> PresupuestosProyecto { get; set; } = new List<PresupuestoProyecto>();
    public ICollection<ComentarioProyecto> ComentariosProyecto { get; set; } = new List<ComentarioProyecto>();
}

public class UsuarioRol
{
    public int UsuarioId { get; set; }
    public int RolId { get; set; }

    public Usuario Usuario { get; set; } = null!;
    public Rol Rol { get; set; } = null!;
}
