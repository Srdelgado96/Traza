using Microsoft.EntityFrameworkCore;
using Traza.Web.Data.Entidades;

namespace Traza.Web.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Departamento> Departamentos => Set<Departamento>();
    public DbSet<Rol> Roles => Set<Rol>();
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<UsuarioRol> UsuariosRol => Set<UsuarioRol>();
    public DbSet<Proceso> Procesos => Set<Proceso>();
    public DbSet<TipologiaIncidencia> TipologiasIncidencia => Set<TipologiaIncidencia>();
    public DbSet<EstadoIncidencia> EstadosIncidencia => Set<EstadoIncidencia>();
    public DbSet<EstadoDetalleIncidencia> EstadosDetalleIncidencia => Set<EstadoDetalleIncidencia>();
    public DbSet<TipoDocumentoReferencia> TiposDocumentoReferencia => Set<TipoDocumentoReferencia>();
    public DbSet<TipoAdjunto> TiposAdjunto => Set<TipoAdjunto>();
    public DbSet<TipoCosteNoCalidad> TiposCosteNoCalidad => Set<TipoCosteNoCalidad>();
    public DbSet<Incidencia> Incidencias => Set<Incidencia>();
    public DbSet<DetalleIncidencia> DetallesIncidencia => Set<DetalleIncidencia>();
    public DbSet<DocumentoIncidencia> DocumentosIncidencia => Set<DocumentoIncidencia>();
    public DbSet<TareaIncidencia> TareasIncidencia => Set<TareaIncidencia>();
    public DbSet<CosteNoCalidadIncidencia> CostesNoCalidadIncidencia => Set<CosteNoCalidadIncidencia>();
    public DbSet<PersonalImplicadoIncidencia> PersonalImplicadoIncidencia => Set<PersonalImplicadoIncidencia>();
    public DbSet<ComentarioIncidencia> ComentariosIncidencia => Set<ComentarioIncidencia>();
    public DbSet<EstadoAccionMejora> EstadosAccionMejora => Set<EstadoAccionMejora>();
    public DbSet<OrigenAccionMejora> OrigenesAccionMejora => Set<OrigenAccionMejora>();
    public DbSet<TipoAccionMejora> TiposAccionMejora => Set<TipoAccionMejora>();
    public DbSet<AccionMejora> AccionesMejora => Set<AccionMejora>();
    public DbSet<DocumentoAccionMejora> DocumentosAccionMejora => Set<DocumentoAccionMejora>();
    public DbSet<TareaAccionMejora> TareasAccionMejora => Set<TareaAccionMejora>();
    public DbSet<ComentarioAccionMejora> ComentariosAccionMejora => Set<ComentarioAccionMejora>();
    public DbSet<AreaProyecto> AreasProyecto => Set<AreaProyecto>();
    public DbSet<EstadoProyecto> EstadosProyecto => Set<EstadoProyecto>();
    public DbSet<PrioridadProyecto> PrioridadesProyecto => Set<PrioridadProyecto>();
    public DbSet<EstadoFaseProyecto> EstadosFaseProyecto => Set<EstadoFaseProyecto>();
    public DbSet<Proyecto> Proyectos => Set<Proyecto>();
    public DbSet<ObjetivoProyecto> ObjetivosProyecto => Set<ObjetivoProyecto>();
    public DbSet<FaseProyecto> FasesProyecto => Set<FaseProyecto>();
    public DbSet<DocumentoProyecto> DocumentosProyecto => Set<DocumentoProyecto>();
    public DbSet<PresupuestoProyecto> PresupuestosProyecto => Set<PresupuestoProyecto>();
    public DbSet<ComentarioProyecto> ComentariosProyecto => Set<ComentarioProyecto>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureCatalogos(modelBuilder);
        ConfigureUsuarios(modelBuilder);
        ConfigureIncidencias(modelBuilder);
        ConfigureAccionesMejora(modelBuilder);
        ConfigureProyectos(modelBuilder);
        SeedCatalogos(modelBuilder);
        SeedUsuarios(modelBuilder);
    }

    private static void ConfigureCatalogos(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.ToTable("Departamentos");
            entity.Property(x => x.Nombre).HasMaxLength(100).IsRequired();
            entity.HasIndex(x => x.Nombre).IsUnique();
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.ToTable("Roles");
            entity.Property(x => x.Nombre).HasMaxLength(100).IsRequired();
            entity.Property(x => x.Descripcion).HasMaxLength(500);
            entity.HasIndex(x => x.Nombre).IsUnique();
        });

        modelBuilder.Entity<Proceso>(entity =>
        {
            entity.ToTable("Procesos");
            entity.Property(x => x.Nombre).HasMaxLength(150).IsRequired();
            entity.HasIndex(x => x.Nombre).IsUnique();
        });

        modelBuilder.Entity<TipologiaIncidencia>(entity =>
        {
            entity.ToTable("TipologiasIncidencia");
            entity.Property(x => x.Nombre).HasMaxLength(200).IsRequired();
            entity.HasIndex(x => new { x.ProcesoId, x.Nombre }).IsUnique();
            entity.HasOne(x => x.Proceso)
                .WithMany(x => x.Tipologias)
                .HasForeignKey(x => x.ProcesoId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<EstadoIncidencia>(entity =>
        {
            entity.ToTable("EstadosIncidencia");
            entity.Property(x => x.Nombre).HasMaxLength(100).IsRequired();
            entity.HasIndex(x => x.Nombre).IsUnique();
        });

        modelBuilder.Entity<EstadoDetalleIncidencia>(entity =>
        {
            entity.ToTable("EstadosDetalleIncidencia");
            entity.Property(x => x.Nombre).HasMaxLength(100).IsRequired();
            entity.HasIndex(x => x.Nombre).IsUnique();
        });

        modelBuilder.Entity<TipoDocumentoReferencia>(entity =>
        {
            entity.ToTable("TiposDocumentoReferencia");
            entity.Property(x => x.Nombre).HasMaxLength(100).IsRequired();
            entity.HasIndex(x => x.Nombre).IsUnique();
        });

        modelBuilder.Entity<TipoAdjunto>(entity =>
        {
            entity.ToTable("TiposAdjunto");
            entity.Property(x => x.Nombre).HasMaxLength(100).IsRequired();
            entity.HasIndex(x => x.Nombre).IsUnique();
        });

        modelBuilder.Entity<TipoCosteNoCalidad>(entity =>
        {
            entity.ToTable("TiposCosteNoCalidad");
            entity.Property(x => x.Nombre).HasMaxLength(100).IsRequired();
            entity.HasIndex(x => x.Nombre).IsUnique();
        });

        modelBuilder.Entity<EstadoAccionMejora>(entity =>
        {
            entity.ToTable("EstadosAccionMejora");
            entity.Property(x => x.Nombre).HasMaxLength(100).IsRequired();
            entity.HasIndex(x => x.Nombre).IsUnique();
        });

        modelBuilder.Entity<OrigenAccionMejora>(entity =>
        {
            entity.ToTable("OrigenesAccionMejora");
            entity.Property(x => x.Nombre).HasMaxLength(100).IsRequired();
            entity.HasIndex(x => x.Nombre).IsUnique();
        });

        modelBuilder.Entity<TipoAccionMejora>(entity =>
        {
            entity.ToTable("TiposAccionMejora");
            entity.Property(x => x.Nombre).HasMaxLength(100).IsRequired();
            entity.HasIndex(x => x.Nombre).IsUnique();
        });

        modelBuilder.Entity<AreaProyecto>(entity =>
        {
            entity.ToTable("AreasProyecto");
            entity.Property(x => x.Nombre).HasMaxLength(100).IsRequired();
            entity.HasIndex(x => x.Nombre).IsUnique();
        });

        modelBuilder.Entity<EstadoProyecto>(entity =>
        {
            entity.ToTable("EstadosProyecto");
            entity.Property(x => x.Nombre).HasMaxLength(100).IsRequired();
            entity.HasIndex(x => x.Nombre).IsUnique();
        });

        modelBuilder.Entity<PrioridadProyecto>(entity =>
        {
            entity.ToTable("PrioridadesProyecto");
            entity.Property(x => x.Nombre).HasMaxLength(50).IsRequired();
            entity.HasIndex(x => x.Nombre).IsUnique();
        });

        modelBuilder.Entity<EstadoFaseProyecto>(entity =>
        {
            entity.ToTable("EstadosFaseProyecto");
            entity.Property(x => x.Nombre).HasMaxLength(100).IsRequired();
            entity.HasIndex(x => x.Nombre).IsUnique();
        });
    }

    private static void ConfigureUsuarios(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("Usuarios");
            entity.Property(x => x.Login).HasMaxLength(50).IsRequired();
            entity.Property(x => x.Nombre).HasMaxLength(150).IsRequired();
            entity.Property(x => x.Email).HasMaxLength(200);
            entity.Property(x => x.Genero).HasMaxLength(20);
            entity.HasIndex(x => x.Login).IsUnique();
            entity.HasOne(x => x.Supervisor)
                .WithMany(x => x.Colaboradores)
                .HasForeignKey(x => x.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.Departamento)
                .WithMany(x => x.Usuarios)
                .HasForeignKey(x => x.DepartamentoId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<UsuarioRol>(entity =>
        {
            entity.ToTable("UsuariosRol");
            entity.HasKey(x => new { x.UsuarioId, x.RolId });
            entity.HasOne(x => x.Usuario)
                .WithMany(x => x.RolesAsignados)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(x => x.Rol)
                .WithMany(x => x.UsuariosRol)
                .HasForeignKey(x => x.RolId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    private static void ConfigureIncidencias(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Incidencia>(entity =>
        {
            entity.ToTable("Incidencias");
            entity.Property(x => x.Descripcion).HasMaxLength(4000).IsRequired();
            entity.Property(x => x.AccionCorrectiva).HasMaxLength(4000);
            entity.Property(x => x.AccionInmediata).HasMaxLength(4000);
            entity.Property(x => x.EvaluacionCierre).HasMaxLength(2000);
            entity.HasOne(x => x.Detector)
                .WithMany(x => x.IncidenciasDetectadas)
                .HasForeignKey(x => x.DetectorId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.Coordinador)
                .WithMany(x => x.IncidenciasCoordinadas)
                .HasForeignKey(x => x.CoordinadorId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.Proceso)
                .WithMany(x => x.Incidencias)
                .HasForeignKey(x => x.ProcesoId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.Tipologia)
                .WithMany(x => x.Incidencias)
                .HasForeignKey(x => x.TipologiaId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.Estado)
                .WithMany(x => x.Incidencias)
                .HasForeignKey(x => x.EstadoId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.AccionMejoraHija)
                .WithMany()
                .HasForeignKey(x => x.AccionMejoraHijaId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<DetalleIncidencia>(entity =>
        {
            entity.ToTable("DetallesIncidencia");
            entity.Property(x => x.Referencia).HasMaxLength(100);
            entity.Property(x => x.Lote).HasMaxLength(100);
            entity.Property(x => x.Cantidad).HasColumnType("decimal(18,2)");
            entity.Property(x => x.Descripcion).HasMaxLength(1000);
            entity.Property(x => x.ClienteProveedor).HasMaxLength(50);
            entity.Property(x => x.Codigo).HasMaxLength(100);
            entity.Property(x => x.NombreIc).HasMaxLength(200);
            entity.Property(x => x.DocumentoReferencia).HasMaxLength(100);
            entity.Property(x => x.Comentarios).HasMaxLength(2000);
            entity.HasOne(x => x.Incidencia)
                .WithMany(x => x.Detalles)
                .HasForeignKey(x => x.IncidenciaId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(x => x.Estado)
                .WithMany(x => x.Detalles)
                .HasForeignKey(x => x.EstadoId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.TipoDocumento)
                .WithMany(x => x.DetallesIncidencia)
                .HasForeignKey(x => x.TipoDocumentoId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<DocumentoIncidencia>(entity =>
        {
            entity.ToTable("DocumentosIncidencia");
            entity.Property(x => x.Titulo).HasMaxLength(200).IsRequired();
            entity.Property(x => x.Descripcion).HasMaxLength(1000);
            entity.Property(x => x.NombreArchivo).HasMaxLength(260).IsRequired();
            entity.Property(x => x.RutaArchivo).HasMaxLength(1000);
            entity.HasOne(x => x.Incidencia)
                .WithMany(x => x.Documentos)
                .HasForeignKey(x => x.IncidenciaId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(x => x.TipoAdjunto)
                .WithMany(x => x.DocumentosIncidencia)
                .HasForeignKey(x => x.TipoAdjuntoId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.Usuario)
                .WithMany(x => x.DocumentosIncidencia)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<TareaIncidencia>(entity =>
        {
            entity.ToTable("TareasIncidencia");
            entity.Property(x => x.Tarea).HasMaxLength(300).IsRequired();
            entity.HasOne(x => x.Incidencia)
                .WithMany(x => x.Tareas)
                .HasForeignKey(x => x.IncidenciaId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(x => x.UsuarioAsignado)
                .WithMany(x => x.TareasIncidencia)
                .HasForeignKey(x => x.UsuarioAsignadoId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<CosteNoCalidadIncidencia>(entity =>
        {
            entity.ToTable("CostesNoCalidadIncidencia");
            entity.Property(x => x.Observaciones).HasMaxLength(1000);
            entity.Property(x => x.Importe).HasColumnType("decimal(18,2)");
            entity.HasOne(x => x.Incidencia)
                .WithMany(x => x.CostesNoCalidad)
                .HasForeignKey(x => x.IncidenciaId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(x => x.Usuario)
                .WithMany(x => x.CostesNoCalidad)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.TipoCoste)
                .WithMany(x => x.Costes)
                .HasForeignKey(x => x.TipoCosteId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<PersonalImplicadoIncidencia>(entity =>
        {
            entity.ToTable("PersonalImplicadoIncidencia");
            entity.Property(x => x.Notas).HasMaxLength(1000);
            entity.HasOne(x => x.Incidencia)
                .WithMany(x => x.PersonalImplicado)
                .HasForeignKey(x => x.IncidenciaId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(x => x.Usuario)
                .WithMany(x => x.IncidenciasPersonalImplicado)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.Departamento)
                .WithMany(x => x.PersonalImplicado)
                .HasForeignKey(x => x.DepartamentoId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<ComentarioIncidencia>(entity =>
        {
            entity.ToTable("ComentariosIncidencia");
            entity.Property(x => x.Contenido).HasMaxLength(4000).IsRequired();
            entity.HasOne(x => x.Incidencia)
                .WithMany(x => x.Comentarios)
                .HasForeignKey(x => x.IncidenciaId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(x => x.Usuario)
                .WithMany(x => x.ComentariosIncidencia)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    private static void ConfigureAccionesMejora(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccionMejora>(entity =>
        {
            entity.ToTable("AccionesMejora");
            entity.Property(x => x.Descripcion).HasMaxLength(4000).IsRequired();
            entity.Property(x => x.AccionInmediata).HasMaxLength(4000);
            entity.Property(x => x.AnalisisCausas).HasMaxLength(4000);
            entity.Property(x => x.PlanAccionPropuesto).HasMaxLength(4000);
            entity.Property(x => x.EvaluacionCierre).HasMaxLength(2000);
            entity.HasOne(x => x.Solicitante)
                .WithMany(x => x.AccionesMejoraSolicitadas)
                .HasForeignKey(x => x.SolicitanteId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.Coordinador)
                .WithMany(x => x.AccionesMejoraCoordinadas)
                .HasForeignKey(x => x.CoordinadorId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.Estado)
                .WithMany(x => x.Acciones)
                .HasForeignKey(x => x.EstadoId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.Origen)
                .WithMany(x => x.Acciones)
                .HasForeignKey(x => x.OrigenId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.TipoAccion)
                .WithMany(x => x.Acciones)
                .HasForeignKey(x => x.TipoAccionId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.IncidenciaOrigen)
                .WithMany(x => x.AccionesMejoraOrigen)
                .HasForeignKey(x => x.IncidenciaOrigenId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.AccionMejoraPadre)
                .WithMany(x => x.AccionesHijas)
                .HasForeignKey(x => x.AccionMejoraPadreId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<DocumentoAccionMejora>(entity =>
        {
            entity.ToTable("DocumentosAccionMejora");
            entity.Property(x => x.Titulo).HasMaxLength(200).IsRequired();
            entity.Property(x => x.Descripcion).HasMaxLength(1000);
            entity.Property(x => x.NombreArchivo).HasMaxLength(260).IsRequired();
            entity.Property(x => x.RutaArchivo).HasMaxLength(1000);
            entity.HasOne(x => x.AccionMejora)
                .WithMany(x => x.Documentos)
                .HasForeignKey(x => x.AccionMejoraId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(x => x.TipoAdjunto)
                .WithMany(x => x.DocumentosAccionMejora)
                .HasForeignKey(x => x.TipoAdjuntoId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.Usuario)
                .WithMany(x => x.DocumentosAccionMejora)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<TareaAccionMejora>(entity =>
        {
            entity.ToTable("TareasAccionMejora");
            entity.Property(x => x.Tarea).HasMaxLength(300).IsRequired();
            entity.HasOne(x => x.AccionMejora)
                .WithMany(x => x.Tareas)
                .HasForeignKey(x => x.AccionMejoraId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(x => x.UsuarioAsignado)
                .WithMany(x => x.TareasAccionMejora)
                .HasForeignKey(x => x.UsuarioAsignadoId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<ComentarioAccionMejora>(entity =>
        {
            entity.ToTable("ComentariosAccionMejora");
            entity.Property(x => x.Contenido).HasMaxLength(4000).IsRequired();
            entity.HasOne(x => x.AccionMejora)
                .WithMany(x => x.Comentarios)
                .HasForeignKey(x => x.AccionMejoraId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(x => x.Usuario)
                .WithMany(x => x.ComentariosAccionMejora)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    private static void ConfigureProyectos(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.ToTable("Proyectos");
            entity.Property(x => x.Nombre).HasMaxLength(300).IsRequired();
            entity.HasIndex(x => x.Numero).IsUnique();
            entity.HasOne(x => x.Area)
                .WithMany(x => x.Proyectos)
                .HasForeignKey(x => x.AreaId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.Estado)
                .WithMany(x => x.Proyectos)
                .HasForeignKey(x => x.EstadoId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.Prioridad)
                .WithMany(x => x.Proyectos)
                .HasForeignKey(x => x.PrioridadId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.Coordinador)
                .WithMany(x => x.ProyectosCoordinados)
                .HasForeignKey(x => x.CoordinadorId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<ObjetivoProyecto>(entity =>
        {
            entity.ToTable("ObjetivosProyecto");
            entity.Property(x => x.Descripcion).HasMaxLength(2000).IsRequired();
            entity.HasOne(x => x.Proyecto)
                .WithMany(x => x.Objetivos)
                .HasForeignKey(x => x.ProyectoId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<FaseProyecto>(entity =>
        {
            entity.ToTable("FasesProyecto");
            entity.Property(x => x.Nombre).HasMaxLength(200).IsRequired();
            entity.HasOne(x => x.Proyecto)
                .WithMany(x => x.Fases)
                .HasForeignKey(x => x.ProyectoId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(x => x.Responsable)
                .WithMany(x => x.FasesProyectoResponsable)
                .HasForeignKey(x => x.ResponsableId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.Estado)
                .WithMany(x => x.Fases)
                .HasForeignKey(x => x.EstadoId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<DocumentoProyecto>(entity =>
        {
            entity.ToTable("DocumentosProyecto");
            entity.Property(x => x.Titulo).HasMaxLength(200).IsRequired();
            entity.Property(x => x.Descripcion).HasMaxLength(1000);
            entity.Property(x => x.NombreArchivo).HasMaxLength(260).IsRequired();
            entity.Property(x => x.RutaArchivo).HasMaxLength(1000);
            entity.HasOne(x => x.Proyecto)
                .WithMany(x => x.Documentos)
                .HasForeignKey(x => x.ProyectoId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(x => x.TipoAdjunto)
                .WithMany(x => x.DocumentosProyecto)
                .HasForeignKey(x => x.TipoAdjuntoId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.Usuario)
                .WithMany(x => x.DocumentosProyecto)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<PresupuestoProyecto>(entity =>
        {
            entity.ToTable("PresupuestosProyecto");
            entity.Property(x => x.ImporteEstimado).HasColumnType("decimal(18,2)");
            entity.Property(x => x.ImportePresupuestado).HasColumnType("decimal(18,2)");
            entity.Property(x => x.ImporteReal).HasColumnType("decimal(18,2)");
            entity.HasOne(x => x.Proyecto)
                .WithMany(x => x.Presupuestos)
                .HasForeignKey(x => x.ProyectoId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(x => x.Usuario)
                .WithMany(x => x.PresupuestosProyecto)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<ComentarioProyecto>(entity =>
        {
            entity.ToTable("ComentariosProyecto");
            entity.Property(x => x.Contenido).HasMaxLength(4000).IsRequired();
            entity.HasOne(x => x.Proyecto)
                .WithMany(x => x.Comentarios)
                .HasForeignKey(x => x.ProyectoId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(x => x.Usuario)
                .WithMany(x => x.ComentariosProyecto)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    private static void SeedCatalogos(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departamento>().HasData(
            new Departamento { Id = 1, Nombre = "Sistemas" },
            new Departamento { Id = 2, Nombre = "Calidad" },
            new Departamento { Id = 3, Nombre = "Producción" },
            new Departamento { Id = 4, Nombre = "Logística" },
            new Departamento { Id = 5, Nombre = "Compras" },
            new Departamento { Id = 6, Nombre = "Comercial" },
            new Departamento { Id = 7, Nombre = "Mantenimiento" },
            new Departamento { Id = 8, Nombre = "Administración" });

        modelBuilder.Entity<Proceso>().HasData(
            new Proceso { Id = 1, Nombre = "Administración" },
            new Proceso { Id = 2, Nombre = "Almacén/Logística" },
            new Proceso { Id = 3, Nombre = "Comercial" },
            new Proceso { Id = 4, Nombre = "Compras" },
            new Proceso { Id = 5, Nombre = "Devoluciones" },
            new Proceso { Id = 6, Nombre = "Diseño y Desarrollo" },
            new Proceso { Id = 7, Nombre = "Fabricación contenido" },
            new Proceso { Id = 8, Nombre = "SGC" },
            new Proceso { Id = 9, Nombre = "Control de Calidad" },
            new Proceso { Id = 10, Nombre = "Mantenimiento" },
            new Proceso { Id = 11, Nombre = "Planificación en Fábrica" },
            new Proceso { Id = 12, Nombre = "Producción" },
            new Proceso { Id = 13, Nombre = "Sistemas" },
            new Proceso { Id = 14, Nombre = "PRL/Seguridad" },
            new Proceso { Id = 15, Nombre = "Quejas de Clientes" },
            new Proceso { Id = 16, Nombre = "Laboratorio/Técnico" },
            new Proceso { Id = 17, Nombre = "Desarrollo de software" },
            new Proceso { Id = 18, Nombre = "Ingeniería" },
            new Proceso { Id = 19, Nombre = "Departamento técnico" },
            new Proceso { Id = 20, Nombre = "Quejas y sugerencias" },
            new Proceso { Id = 21, Nombre = "Sala Blanca" });

        var tipologias = new List<TipologiaIncidencia>();
        var tipologiaId = 1;

        foreach (var procesoId in Enumerable.Range(1, 21))
        {
            tipologias.Add(new TipologiaIncidencia
            {
                Id = tipologiaId++,
                ProcesoId = procesoId,
                Nombre = "Sin definir",
                Activa = true
            });
        }

        tipologias.AddRange(
        [
            new TipologiaIncidencia { Id = tipologiaId++, ProcesoId = 2, Nombre = "Falta de identificación de mercancía", Activa = true },
            new TipologiaIncidencia { Id = tipologiaId++, ProcesoId = 2, Nombre = "Error de identificación", Activa = true },
            new TipologiaIncidencia { Id = tipologiaId++, ProcesoId = 2, Nombre = "Error preparación de pedidos", Activa = true },
            new TipologiaIncidencia { Id = tipologiaId++, ProcesoId = 2, Nombre = "Error de movimiento de mercancía", Activa = true },
            new TipologiaIncidencia { Id = tipologiaId++, ProcesoId = 2, Nombre = "Rotura/daño en mercancía", Activa = true },
            new TipologiaIncidencia { Id = tipologiaId++, ProcesoId = 2, Nombre = "Descuadres de stock", Activa = true },
            new TipologiaIncidencia { Id = tipologiaId++, ProcesoId = 2, Nombre = "Descuadres detectados en almacenes exteriores durante el arqueo periódico", Activa = true },
            new TipologiaIncidencia { Id = tipologiaId++, ProcesoId = 2, Nombre = "Desviaciones importantes en inventario", Activa = true },
            new TipologiaIncidencia { Id = tipologiaId++, ProcesoId = 2, Nombre = "Falta de mercancía", Activa = true }
        ]);

        modelBuilder.Entity<TipologiaIncidencia>().HasData(tipologias);

        modelBuilder.Entity<EstadoIncidencia>().HasData(
            new EstadoIncidencia { Id = 1, Nombre = "Nueva", Orden = 1, EsCierre = false },
            new EstadoIncidencia { Id = 2, Nombre = "En análisis", Orden = 2, EsCierre = false },
            new EstadoIncidencia { Id = 3, Nombre = "En gestión", Orden = 3, EsCierre = false },
            new EstadoIncidencia { Id = 4, Nombre = "Cerrada", Orden = 4, EsCierre = true });

        modelBuilder.Entity<EstadoDetalleIncidencia>().HasData(
            new EstadoDetalleIncidencia { Id = 1, Nombre = "Pendiente", Orden = 1 },
            new EstadoDetalleIncidencia { Id = 2, Nombre = "Aceptado", Orden = 2 },
            new EstadoDetalleIncidencia { Id = 3, Nombre = "Devolución", Orden = 3 },
            new EstadoDetalleIncidencia { Id = 4, Nombre = "Devolución parcial", Orden = 4 },
            new EstadoDetalleIncidencia { Id = 5, Nombre = "Destrucción", Orden = 5 },
            new EstadoDetalleIncidencia { Id = 6, Nombre = "N/A", Orden = 6 });

        modelBuilder.Entity<TipoDocumentoReferencia>().HasData(
            new TipoDocumentoReferencia { Id = 1, Nombre = "N/A" },
            new TipoDocumentoReferencia { Id = 2, Nombre = "Presupuesto" },
            new TipoDocumentoReferencia { Id = 3, Nombre = "Pedido" },
            new TipoDocumentoReferencia { Id = 4, Nombre = "Albarán" },
            new TipoDocumentoReferencia { Id = 5, Nombre = "Factura" },
            new TipoDocumentoReferencia { Id = 6, Nombre = "Parte de fabricación" },
            new TipoDocumentoReferencia { Id = 7, Nombre = "Preparación de material" },
            new TipoDocumentoReferencia { Id = 8, Nombre = "Vale de transporte" },
            new TipoDocumentoReferencia { Id = 9, Nombre = "Movimiento entre almacenes" },
            new TipoDocumentoReferencia { Id = 10, Nombre = "Packing List" },
            new TipoDocumentoReferencia { Id = 11, Nombre = "Vale de entrada almacén" });

        modelBuilder.Entity<TipoAdjunto>().HasData(
            new TipoAdjunto { Id = 1, Nombre = "Fotografías" },
            new TipoAdjunto { Id = 2, Nombre = "Informe de calidad" },
            new TipoAdjunto { Id = 3, Nombre = "Documento" },
            new TipoAdjunto { Id = 4, Nombre = "Otros" });

        modelBuilder.Entity<TipoCosteNoCalidad>().HasData(
            new TipoCosteNoCalidad { Id = 1, Nombre = "Recuperado" },
            new TipoCosteNoCalidad { Id = 2, Nombre = "Destrucción" },
            new TipoCosteNoCalidad { Id = 3, Nombre = "Transporte" },
            new TipoCosteNoCalidad { Id = 4, Nombre = "Reproceso" },
            new TipoCosteNoCalidad { Id = 5, Nombre = "Cliente" },
            new TipoCosteNoCalidad { Id = 6, Nombre = "Otros" });

        modelBuilder.Entity<EstadoAccionMejora>().HasData(
            new EstadoAccionMejora { Id = 1, Nombre = "Idea", Orden = 1, EsCierre = false },
            new EstadoAccionMejora { Id = 2, Nombre = "En desarrollo", Orden = 2, EsCierre = false },
            new EstadoAccionMejora { Id = 3, Nombre = "En revisión", Orden = 3, EsCierre = false },
            new EstadoAccionMejora { Id = 4, Nombre = "Stand by", Orden = 4, EsCierre = false },
            new EstadoAccionMejora { Id = 5, Nombre = "Cancelado", Orden = 5, EsCierre = true },
            new EstadoAccionMejora { Id = 6, Nombre = "Terminado", Orden = 6, EsCierre = true });

        modelBuilder.Entity<OrigenAccionMejora>().HasData(
            new OrigenAccionMejora { Id = 1, Nombre = "Acción de mejora" },
            new OrigenAccionMejora { Id = 2, Nombre = "Auditoría" },
            new OrigenAccionMejora { Id = 3, Nombre = "Comité calidad" },
            new OrigenAccionMejora { Id = 4, Nombre = "Incidencia" },
            new OrigenAccionMejora { Id = 5, Nombre = "Interna" },
            new OrigenAccionMejora { Id = 6, Nombre = "Otros" },
            new OrigenAccionMejora { Id = 7, Nombre = "Preventiva" },
            new OrigenAccionMejora { Id = 8, Nombre = "Reclamación cliente" },
            new OrigenAccionMejora { Id = 9, Nombre = "Sugerencias de mejora" });

        modelBuilder.Entity<TipoAccionMejora>().HasData(
            new TipoAccionMejora { Id = 1, Nombre = "Proyecto de mejora" },
            new TipoAccionMejora { Id = 2, Nombre = "Acción correctiva" },
            new TipoAccionMejora { Id = 3, Nombre = "Acción preventiva" },
            new TipoAccionMejora { Id = 4, Nombre = "Reclamación" });

        modelBuilder.Entity<AreaProyecto>().HasData(
            new AreaProyecto { Id = 1, Nombre = "Sin definir" },
            new AreaProyecto { Id = 2, Nombre = "Arte" },
            new AreaProyecto { Id = 3, Nombre = "Azentis" },
            new AreaProyecto { Id = 4, Nombre = "Bodega" },
            new AreaProyecto { Id = 5, Nombre = "Calidad" },
            new AreaProyecto { Id = 6, Nombre = "Comercial" },
            new AreaProyecto { Id = 7, Nombre = "Compras" },
            new AreaProyecto { Id = 8, Nombre = "Contabilidad" },
            new AreaProyecto { Id = 9, Nombre = "Control de Stock" },
            new AreaProyecto { Id = 10, Nombre = "Devoluciones" },
            new AreaProyecto { Id = 11, Nombre = "Dirección" },
            new AreaProyecto { Id = 12, Nombre = "Diseño" },
            new AreaProyecto { Id = 13, Nombre = "Enlace Facturación" },
            new AreaProyecto { Id = 14, Nombre = "Estadística" },
            new AreaProyecto { Id = 15, Nombre = "Fábrica" },
            new AreaProyecto { Id = 16, Nombre = "Facturación" },
            new AreaProyecto { Id = 17, Nombre = "Logística" },
            new AreaProyecto { Id = 18, Nombre = "Mantenimiento" },
            new AreaProyecto { Id = 19, Nombre = "Marketing" },
            new AreaProyecto { Id = 20, Nombre = "Producción" },
            new AreaProyecto { Id = 21, Nombre = "Sistemas" },
            new AreaProyecto { Id = 22, Nombre = "Tesorería" });

        modelBuilder.Entity<EstadoProyecto>().HasData(
            new EstadoProyecto { Id = 1, Nombre = "Idea", Orden = 1, EsCierre = false },
            new EstadoProyecto { Id = 2, Nombre = "En desarrollo", Orden = 2, EsCierre = false },
            new EstadoProyecto { Id = 3, Nombre = "En revisión", Orden = 3, EsCierre = false },
            new EstadoProyecto { Id = 4, Nombre = "Stand by", Orden = 4, EsCierre = false },
            new EstadoProyecto { Id = 5, Nombre = "Cancelado", Orden = 5, EsCierre = true },
            new EstadoProyecto { Id = 6, Nombre = "Terminado", Orden = 6, EsCierre = true });

        modelBuilder.Entity<PrioridadProyecto>().HasData(
            new PrioridadProyecto { Id = 1, Nombre = "Alta", Orden = 1 },
            new PrioridadProyecto { Id = 2, Nombre = "Media", Orden = 2 },
            new PrioridadProyecto { Id = 3, Nombre = "Baja", Orden = 3 });

        modelBuilder.Entity<EstadoFaseProyecto>().HasData(
            new EstadoFaseProyecto { Id = 1, Nombre = "Idea", Orden = 1, EsCierre = false },
            new EstadoFaseProyecto { Id = 2, Nombre = "En desarrollo", Orden = 2, EsCierre = false },
            new EstadoFaseProyecto { Id = 3, Nombre = "En revisión", Orden = 3, EsCierre = false },
            new EstadoFaseProyecto { Id = 4, Nombre = "Stand by", Orden = 4, EsCierre = false },
            new EstadoFaseProyecto { Id = 5, Nombre = "Cancelado", Orden = 5, EsCierre = true },
            new EstadoFaseProyecto { Id = 6, Nombre = "Terminado", Orden = 6, EsCierre = true });

        modelBuilder.Entity<Rol>().HasData(
            new Rol { Id = 1, Nombre = "Administrador", Descripcion = "Acceso completo a la aplicacion.", Activo = true },
            new Rol { Id = 2, Nombre = "Calidad", Descripcion = "Gestion funcional de incidencias y acciones.", Activo = true },
            new Rol { Id = 3, Nombre = "Proyectos", Descripcion = "Seguimiento y coordinacion de proyectos.", Activo = true },
            new Rol { Id = 4, Nombre = "Consulta", Descripcion = "Acceso de solo consulta.", Activo = true });
    }

    private static void SeedUsuarios(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>().HasData(
            new Usuario { Id = 1, Login = "adelgado", Nombre = "Alejandro Delgado", Email = "adelgado@traza.local", DepartamentoId = 1, Activo = true },
            new Usuario { Id = 2, Login = "rtorres", Nombre = "Rocío Torres", Email = "rtorres@traza.local", DepartamentoId = 2, Activo = true },
            new Usuario { Id = 3, Login = "prodriguez", Nombre = "Pablo Rodríguez", Email = "prodriguez@traza.local", DepartamentoId = 3, Activo = true },
            new Usuario { Id = 4, Login = "mpromero", Nombre = "Mari Paz Romero", Email = "mpromero@traza.local", DepartamentoId = 4, Activo = true });

        modelBuilder.Entity<UsuarioRol>().HasData(
            new UsuarioRol { UsuarioId = 1, RolId = 1 },
            new UsuarioRol { UsuarioId = 1, RolId = 3 },
            new UsuarioRol { UsuarioId = 2, RolId = 2 },
            new UsuarioRol { UsuarioId = 3, RolId = 4 },
            new UsuarioRol { UsuarioId = 4, RolId = 4 });
    }
}
