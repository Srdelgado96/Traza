using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Traza.Web.Migrations
{
    /// <inheritdoc />
    public partial class EsquemaInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreasProyecto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasProyecto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadosAccionMejora",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    EsCierre = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosAccionMejora", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadosDetalleIncidencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosDetalleIncidencia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadosFaseProyecto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    EsCierre = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosFaseProyecto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadosIncidencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    EsCierre = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosIncidencia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadosProyecto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    EsCierre = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosProyecto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrigenesAccionMejora",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrigenesAccionMejora", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrioridadesProyecto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrioridadesProyecto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Procesos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procesos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposAccionMejora",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposAccionMejora", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposAdjunto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposAdjunto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposCosteNoCalidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposCosteNoCalidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposDocumentoReferencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDocumentoReferencia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SupervisorId = table.Column<int>(type: "int", nullable: true),
                    DepartamentoId = table.Column<int>(type: "int", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Usuarios_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipologiasIncidencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcesoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Activa = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipologiasIncidencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipologiasIncidencia_Procesos_ProcesoId",
                        column: x => x.ProcesoId,
                        principalTable: "Procesos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCierre = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    PrioridadId = table.Column<int>(type: "int", nullable: false),
                    CoordinadorId = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ModificadoEn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proyectos_AreasProyecto_AreaId",
                        column: x => x.AreaId,
                        principalTable: "AreasProyecto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proyectos_EstadosProyecto_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "EstadosProyecto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proyectos_PrioridadesProyecto_PrioridadId",
                        column: x => x.PrioridadId,
                        principalTable: "PrioridadesProyecto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proyectos_Usuarios_CoordinadorId",
                        column: x => x.CoordinadorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComentariosProyecto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProyectoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contenido = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    EsSeguimiento = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentariosProyecto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComentariosProyecto_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComentariosProyecto_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocumentosProyecto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProyectoId = table.Column<int>(type: "int", nullable: false),
                    TipoAdjuntoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    FechaDocumento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    NombreArchivo = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: false),
                    RutaArchivo = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentosProyecto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentosProyecto_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentosProyecto_TiposAdjunto_TipoAdjuntoId",
                        column: x => x.TipoAdjuntoId,
                        principalTable: "TiposAdjunto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentosProyecto_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FasesProyecto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProyectoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ResponsableId = table.Column<int>(type: "int", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaObjetivo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaReal = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FasesProyecto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FasesProyecto_EstadosFaseProyecto_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "EstadosFaseProyecto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FasesProyecto_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FasesProyecto_Usuarios_ResponsableId",
                        column: x => x.ResponsableId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ObjetivosProyecto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProyectoId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetivosProyecto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjetivosProyecto_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PresupuestosProyecto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProyectoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    FechaEstimacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImporteEstimado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaPresupuesto = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImportePresupuestado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaReal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImporteReal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresupuestosProyecto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PresupuestosProyecto_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PresupuestosProyecto_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccionesMejora",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaObjetivo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SolicitanteId = table.Column<int>(type: "int", nullable: false),
                    CoordinadorId = table.Column<int>(type: "int", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    OrigenId = table.Column<int>(type: "int", nullable: true),
                    TipoAccionId = table.Column<int>(type: "int", nullable: true),
                    IncidenciaOrigenId = table.Column<int>(type: "int", nullable: true),
                    AccionMejoraPadreId = table.Column<int>(type: "int", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    AccionInmediata = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    AnalisisCausas = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    PlanAccionPropuesto = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    Cerrada = table.Column<bool>(type: "bit", nullable: false),
                    FechaCierre = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EvaluacionCierre = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ModificadaEn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccionesMejora", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccionesMejora_AccionesMejora_AccionMejoraPadreId",
                        column: x => x.AccionMejoraPadreId,
                        principalTable: "AccionesMejora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccionesMejora_EstadosAccionMejora_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "EstadosAccionMejora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccionesMejora_OrigenesAccionMejora_OrigenId",
                        column: x => x.OrigenId,
                        principalTable: "OrigenesAccionMejora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccionesMejora_TiposAccionMejora_TipoAccionId",
                        column: x => x.TipoAccionId,
                        principalTable: "TiposAccionMejora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccionesMejora_Usuarios_CoordinadorId",
                        column: x => x.CoordinadorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccionesMejora_Usuarios_SolicitanteId",
                        column: x => x.SolicitanteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComentariosAccionMejora",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccionMejoraId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contenido = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    EsSeguimiento = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentariosAccionMejora", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComentariosAccionMejora_AccionesMejora_AccionMejoraId",
                        column: x => x.AccionMejoraId,
                        principalTable: "AccionesMejora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComentariosAccionMejora_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocumentosAccionMejora",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccionMejoraId = table.Column<int>(type: "int", nullable: false),
                    TipoAdjuntoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    FechaDocumento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    NombreArchivo = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: false),
                    RutaArchivo = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentosAccionMejora", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentosAccionMejora_AccionesMejora_AccionMejoraId",
                        column: x => x.AccionMejoraId,
                        principalTable: "AccionesMejora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentosAccionMejora_TiposAdjunto_TipoAdjuntoId",
                        column: x => x.TipoAdjuntoId,
                        principalTable: "TiposAdjunto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentosAccionMejora_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Incidencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaGestion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DetectorId = table.Column<int>(type: "int", nullable: false),
                    CoordinadorId = table.Column<int>(type: "int", nullable: true),
                    ProcesoId = table.Column<int>(type: "int", nullable: false),
                    TipologiaId = table.Column<int>(type: "int", nullable: true),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    AccionCorrectiva = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    AccionInmediata = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    Cerrada = table.Column<bool>(type: "bit", nullable: false),
                    FechaCierre = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EvaluacionCierre = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    GeneraAccionMejora = table.Column<bool>(type: "bit", nullable: false),
                    AccionMejoraHijaId = table.Column<int>(type: "int", nullable: true),
                    ModificadaEn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incidencias_AccionesMejora_AccionMejoraHijaId",
                        column: x => x.AccionMejoraHijaId,
                        principalTable: "AccionesMejora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidencias_EstadosIncidencia_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "EstadosIncidencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidencias_Procesos_ProcesoId",
                        column: x => x.ProcesoId,
                        principalTable: "Procesos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidencias_TipologiasIncidencia_TipologiaId",
                        column: x => x.TipologiaId,
                        principalTable: "TipologiasIncidencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidencias_Usuarios_CoordinadorId",
                        column: x => x.CoordinadorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidencias_Usuarios_DetectorId",
                        column: x => x.DetectorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TareasAccionMejora",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccionMejoraId = table.Column<int>(type: "int", nullable: false),
                    UsuarioAsignadoId = table.Column<int>(type: "int", nullable: false),
                    Tarea = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FechaFinEsperada = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EsUrgente = table.Column<bool>(type: "bit", nullable: false),
                    Cerrada = table.Column<bool>(type: "bit", nullable: false),
                    FechaCierre = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TareasAccionMejora", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TareasAccionMejora_AccionesMejora_AccionMejoraId",
                        column: x => x.AccionMejoraId,
                        principalTable: "AccionesMejora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TareasAccionMejora_Usuarios_UsuarioAsignadoId",
                        column: x => x.UsuarioAsignadoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComentariosIncidencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncidenciaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contenido = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    EsSeguimiento = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentariosIncidencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComentariosIncidencia_Incidencias_IncidenciaId",
                        column: x => x.IncidenciaId,
                        principalTable: "Incidencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComentariosIncidencia_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CostesNoCalidadIncidencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncidenciaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoCosteId = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Importe = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostesNoCalidadIncidencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostesNoCalidadIncidencia_Incidencias_IncidenciaId",
                        column: x => x.IncidenciaId,
                        principalTable: "Incidencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CostesNoCalidadIncidencia_TiposCosteNoCalidad_TipoCosteId",
                        column: x => x.TipoCosteId,
                        principalTable: "TiposCosteNoCalidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CostesNoCalidadIncidencia_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetallesIncidencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncidenciaId = table.Column<int>(type: "int", nullable: false),
                    Referencia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Lote = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ClienteProveedor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NombreIc = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: true),
                    DocumentoReferencia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Comentarios = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesIncidencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallesIncidencia_EstadosDetalleIncidencia_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "EstadosDetalleIncidencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetallesIncidencia_Incidencias_IncidenciaId",
                        column: x => x.IncidenciaId,
                        principalTable: "Incidencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesIncidencia_TiposDocumentoReferencia_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalTable: "TiposDocumentoReferencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocumentosIncidencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncidenciaId = table.Column<int>(type: "int", nullable: false),
                    TipoAdjuntoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    FechaDocumento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    NombreArchivo = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: false),
                    RutaArchivo = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentosIncidencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentosIncidencia_Incidencias_IncidenciaId",
                        column: x => x.IncidenciaId,
                        principalTable: "Incidencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentosIncidencia_TiposAdjunto_TipoAdjuntoId",
                        column: x => x.TipoAdjuntoId,
                        principalTable: "TiposAdjunto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocumentosIncidencia_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonalImplicadoIncidencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncidenciaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: true),
                    Notas = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalImplicadoIncidencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalImplicadoIncidencia_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonalImplicadoIncidencia_Incidencias_IncidenciaId",
                        column: x => x.IncidenciaId,
                        principalTable: "Incidencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalImplicadoIncidencia_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TareasIncidencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncidenciaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioAsignadoId = table.Column<int>(type: "int", nullable: false),
                    Tarea = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FechaFinEsperada = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EsUrgente = table.Column<bool>(type: "bit", nullable: false),
                    Cerrada = table.Column<bool>(type: "bit", nullable: false),
                    FechaCierre = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TareasIncidencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TareasIncidencia_Incidencias_IncidenciaId",
                        column: x => x.IncidenciaId,
                        principalTable: "Incidencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TareasIncidencia_Usuarios_UsuarioAsignadoId",
                        column: x => x.UsuarioAsignadoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AreasProyecto",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Sin definir" },
                    { 2, "Arte" },
                    { 3, "Azentis" },
                    { 4, "Bodega" },
                    { 5, "Calidad" },
                    { 6, "Comercial" },
                    { 7, "Compras" },
                    { 8, "Contabilidad" },
                    { 9, "Control de Stock" },
                    { 10, "Devoluciones" },
                    { 11, "Dirección" },
                    { 12, "Diseño" },
                    { 13, "Enlace Facturación" },
                    { 14, "Estadística" },
                    { 15, "Fábrica" },
                    { 16, "Facturación" },
                    { 17, "Logística" },
                    { 18, "Mantenimiento" },
                    { 19, "Marketing" },
                    { 20, "Producción" },
                    { 21, "Sistemas" },
                    { 22, "Tesorería" }
                });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Sistemas" },
                    { 2, "Calidad" },
                    { 3, "Producción" },
                    { 4, "Logística" },
                    { 5, "Compras" },
                    { 6, "Comercial" },
                    { 7, "Mantenimiento" },
                    { 8, "Administración" }
                });

            migrationBuilder.InsertData(
                table: "EstadosAccionMejora",
                columns: new[] { "Id", "EsCierre", "Nombre", "Orden" },
                values: new object[,]
                {
                    { 1, false, "Idea", 1 },
                    { 2, false, "En desarrollo", 2 },
                    { 3, false, "En revisión", 3 },
                    { 4, false, "Stand by", 4 },
                    { 5, true, "Cancelado", 5 },
                    { 6, true, "Terminado", 6 }
                });

            migrationBuilder.InsertData(
                table: "EstadosDetalleIncidencia",
                columns: new[] { "Id", "Nombre", "Orden" },
                values: new object[,]
                {
                    { 1, "Pendiente", 1 },
                    { 2, "Aceptado", 2 },
                    { 3, "Devolución", 3 },
                    { 4, "Devolución parcial", 4 },
                    { 5, "Destrucción", 5 },
                    { 6, "N/A", 6 }
                });

            migrationBuilder.InsertData(
                table: "EstadosFaseProyecto",
                columns: new[] { "Id", "EsCierre", "Nombre", "Orden" },
                values: new object[,]
                {
                    { 1, false, "Idea", 1 },
                    { 2, false, "En desarrollo", 2 },
                    { 3, false, "En revisión", 3 },
                    { 4, false, "Stand by", 4 },
                    { 5, true, "Cancelado", 5 },
                    { 6, true, "Terminado", 6 }
                });

            migrationBuilder.InsertData(
                table: "EstadosIncidencia",
                columns: new[] { "Id", "EsCierre", "Nombre", "Orden" },
                values: new object[,]
                {
                    { 1, false, "Nueva", 1 },
                    { 2, false, "En análisis", 2 },
                    { 3, false, "En gestión", 3 },
                    { 4, true, "Cerrada", 4 }
                });

            migrationBuilder.InsertData(
                table: "EstadosProyecto",
                columns: new[] { "Id", "EsCierre", "Nombre", "Orden" },
                values: new object[,]
                {
                    { 1, false, "Idea", 1 },
                    { 2, false, "En desarrollo", 2 },
                    { 3, false, "En revisión", 3 },
                    { 4, false, "Stand by", 4 },
                    { 5, true, "Cancelado", 5 },
                    { 6, true, "Terminado", 6 }
                });

            migrationBuilder.InsertData(
                table: "OrigenesAccionMejora",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Acción de mejora" },
                    { 2, "Auditoría" },
                    { 3, "Comité calidad" },
                    { 4, "Incidencia" },
                    { 5, "Interna" },
                    { 6, "Otros" },
                    { 7, "Preventiva" },
                    { 8, "Reclamación cliente" },
                    { 9, "Sugerencias de mejora" }
                });

            migrationBuilder.InsertData(
                table: "PrioridadesProyecto",
                columns: new[] { "Id", "Nombre", "Orden" },
                values: new object[,]
                {
                    { 1, "Alta", 1 },
                    { 2, "Media", 2 },
                    { 3, "Baja", 3 }
                });

            migrationBuilder.InsertData(
                table: "Procesos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Administración" },
                    { 2, "Almacén/Logística" },
                    { 3, "Comercial" },
                    { 4, "Compras" },
                    { 5, "Devoluciones" },
                    { 6, "Diseño y Desarrollo" },
                    { 7, "Fabricación contenido" },
                    { 8, "SGC" },
                    { 9, "Control de Calidad" },
                    { 10, "Mantenimiento" },
                    { 11, "Planificación en Fábrica" },
                    { 12, "Producción" },
                    { 13, "Sistemas" },
                    { 14, "PRL/Seguridad" },
                    { 15, "Quejas de Clientes" },
                    { 16, "Laboratorio/Técnico" },
                    { 17, "Desarrollo de software" },
                    { 18, "Ingeniería" },
                    { 19, "Departamento técnico" },
                    { 20, "Quejas y sugerencias" },
                    { 21, "Sala Blanca" }
                });

            migrationBuilder.InsertData(
                table: "TiposAccionMejora",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Proyecto de mejora" },
                    { 2, "Acción correctiva" },
                    { 3, "Acción preventiva" },
                    { 4, "Reclamación" }
                });

            migrationBuilder.InsertData(
                table: "TiposAdjunto",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Fotografías" },
                    { 2, "Informe de calidad" },
                    { 3, "Documento" },
                    { 4, "Otros" }
                });

            migrationBuilder.InsertData(
                table: "TiposCosteNoCalidad",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Recuperado" },
                    { 2, "Destrucción" },
                    { 3, "Transporte" },
                    { 4, "Reproceso" },
                    { 5, "Cliente" },
                    { 6, "Otros" }
                });

            migrationBuilder.InsertData(
                table: "TiposDocumentoReferencia",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "N/A" },
                    { 2, "Presupuesto" },
                    { 3, "Pedido" },
                    { 4, "Albarán" },
                    { 5, "Factura" },
                    { 6, "Parte de fabricación" },
                    { 7, "Preparación de material" },
                    { 8, "Vale de transporte" },
                    { 9, "Movimiento entre almacenes" },
                    { 10, "Packing List" },
                    { 11, "Vale de entrada almacén" }
                });

            migrationBuilder.InsertData(
                table: "TipologiasIncidencia",
                columns: new[] { "Id", "Activa", "Nombre", "ProcesoId" },
                values: new object[,]
                {
                    { 1, true, "Sin definir", 1 },
                    { 2, true, "Sin definir", 2 },
                    { 3, true, "Sin definir", 3 },
                    { 4, true, "Sin definir", 4 },
                    { 5, true, "Sin definir", 5 },
                    { 6, true, "Sin definir", 6 },
                    { 7, true, "Sin definir", 7 },
                    { 8, true, "Sin definir", 8 },
                    { 9, true, "Sin definir", 9 },
                    { 10, true, "Sin definir", 10 },
                    { 11, true, "Sin definir", 11 },
                    { 12, true, "Sin definir", 12 },
                    { 13, true, "Sin definir", 13 },
                    { 14, true, "Sin definir", 14 },
                    { 15, true, "Sin definir", 15 },
                    { 16, true, "Sin definir", 16 },
                    { 17, true, "Sin definir", 17 },
                    { 18, true, "Sin definir", 18 },
                    { 19, true, "Sin definir", 19 },
                    { 20, true, "Sin definir", 20 },
                    { 21, true, "Sin definir", 21 },
                    { 22, true, "Falta de identificación de mercancía", 2 },
                    { 23, true, "Error de identificación", 2 },
                    { 24, true, "Error preparación de pedidos", 2 },
                    { 25, true, "Error de movimiento de mercancía", 2 },
                    { 26, true, "Rotura/daño en mercancía", 2 },
                    { 27, true, "Descuadres de stock", 2 },
                    { 28, true, "Descuadres detectados en almacenes exteriores durante el arqueo periódico", 2 },
                    { 29, true, "Desviaciones importantes en inventario", 2 },
                    { 30, true, "Falta de mercancía", 2 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Activo", "DepartamentoId", "Email", "Genero", "Login", "Nombre", "SupervisorId" },
                values: new object[,]
                {
                    { 1, true, 1, "adelgado@traza.local", null, "adelgado", "Alejandro Delgado", null },
                    { 2, true, 2, "rtorres@traza.local", null, "rtorres", "Rocío Torres", null },
                    { 3, true, 3, "prodriguez@traza.local", null, "prodriguez", "Pablo Rodríguez", null },
                    { 4, true, 4, "mpromero@traza.local", null, "mpromero", "Mari Paz Romero", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccionesMejora_AccionMejoraPadreId",
                table: "AccionesMejora",
                column: "AccionMejoraPadreId");

            migrationBuilder.CreateIndex(
                name: "IX_AccionesMejora_CoordinadorId",
                table: "AccionesMejora",
                column: "CoordinadorId");

            migrationBuilder.CreateIndex(
                name: "IX_AccionesMejora_EstadoId",
                table: "AccionesMejora",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_AccionesMejora_IncidenciaOrigenId",
                table: "AccionesMejora",
                column: "IncidenciaOrigenId");

            migrationBuilder.CreateIndex(
                name: "IX_AccionesMejora_OrigenId",
                table: "AccionesMejora",
                column: "OrigenId");

            migrationBuilder.CreateIndex(
                name: "IX_AccionesMejora_SolicitanteId",
                table: "AccionesMejora",
                column: "SolicitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_AccionesMejora_TipoAccionId",
                table: "AccionesMejora",
                column: "TipoAccionId");

            migrationBuilder.CreateIndex(
                name: "IX_AreasProyecto_Nombre",
                table: "AreasProyecto",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComentariosAccionMejora_AccionMejoraId",
                table: "ComentariosAccionMejora",
                column: "AccionMejoraId");

            migrationBuilder.CreateIndex(
                name: "IX_ComentariosAccionMejora_UsuarioId",
                table: "ComentariosAccionMejora",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ComentariosIncidencia_IncidenciaId",
                table: "ComentariosIncidencia",
                column: "IncidenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_ComentariosIncidencia_UsuarioId",
                table: "ComentariosIncidencia",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ComentariosProyecto_ProyectoId",
                table: "ComentariosProyecto",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_ComentariosProyecto_UsuarioId",
                table: "ComentariosProyecto",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_CostesNoCalidadIncidencia_IncidenciaId",
                table: "CostesNoCalidadIncidencia",
                column: "IncidenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_CostesNoCalidadIncidencia_TipoCosteId",
                table: "CostesNoCalidadIncidencia",
                column: "TipoCosteId");

            migrationBuilder.CreateIndex(
                name: "IX_CostesNoCalidadIncidencia_UsuarioId",
                table: "CostesNoCalidadIncidencia",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_Nombre",
                table: "Departamentos",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetallesIncidencia_EstadoId",
                table: "DetallesIncidencia",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesIncidencia_IncidenciaId",
                table: "DetallesIncidencia",
                column: "IncidenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesIncidencia_TipoDocumentoId",
                table: "DetallesIncidencia",
                column: "TipoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentosAccionMejora_AccionMejoraId",
                table: "DocumentosAccionMejora",
                column: "AccionMejoraId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentosAccionMejora_TipoAdjuntoId",
                table: "DocumentosAccionMejora",
                column: "TipoAdjuntoId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentosAccionMejora_UsuarioId",
                table: "DocumentosAccionMejora",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentosIncidencia_IncidenciaId",
                table: "DocumentosIncidencia",
                column: "IncidenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentosIncidencia_TipoAdjuntoId",
                table: "DocumentosIncidencia",
                column: "TipoAdjuntoId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentosIncidencia_UsuarioId",
                table: "DocumentosIncidencia",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentosProyecto_ProyectoId",
                table: "DocumentosProyecto",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentosProyecto_TipoAdjuntoId",
                table: "DocumentosProyecto",
                column: "TipoAdjuntoId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentosProyecto_UsuarioId",
                table: "DocumentosProyecto",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadosAccionMejora_Nombre",
                table: "EstadosAccionMejora",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EstadosDetalleIncidencia_Nombre",
                table: "EstadosDetalleIncidencia",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EstadosFaseProyecto_Nombre",
                table: "EstadosFaseProyecto",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EstadosIncidencia_Nombre",
                table: "EstadosIncidencia",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EstadosProyecto_Nombre",
                table: "EstadosProyecto",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FasesProyecto_EstadoId",
                table: "FasesProyecto",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_FasesProyecto_ProyectoId",
                table: "FasesProyecto",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_FasesProyecto_ResponsableId",
                table: "FasesProyecto",
                column: "ResponsableId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_AccionMejoraHijaId",
                table: "Incidencias",
                column: "AccionMejoraHijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_CoordinadorId",
                table: "Incidencias",
                column: "CoordinadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_DetectorId",
                table: "Incidencias",
                column: "DetectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_EstadoId",
                table: "Incidencias",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_ProcesoId",
                table: "Incidencias",
                column: "ProcesoId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_TipologiaId",
                table: "Incidencias",
                column: "TipologiaId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjetivosProyecto_ProyectoId",
                table: "ObjetivosProyecto",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrigenesAccionMejora_Nombre",
                table: "OrigenesAccionMejora",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalImplicadoIncidencia_DepartamentoId",
                table: "PersonalImplicadoIncidencia",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalImplicadoIncidencia_IncidenciaId",
                table: "PersonalImplicadoIncidencia",
                column: "IncidenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalImplicadoIncidencia_UsuarioId",
                table: "PersonalImplicadoIncidencia",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PresupuestosProyecto_ProyectoId",
                table: "PresupuestosProyecto",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_PresupuestosProyecto_UsuarioId",
                table: "PresupuestosProyecto",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PrioridadesProyecto_Nombre",
                table: "PrioridadesProyecto",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Procesos_Nombre",
                table: "Procesos",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_AreaId",
                table: "Proyectos",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_CoordinadorId",
                table: "Proyectos",
                column: "CoordinadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_EstadoId",
                table: "Proyectos",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_Numero",
                table: "Proyectos",
                column: "Numero",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_PrioridadId",
                table: "Proyectos",
                column: "PrioridadId");

            migrationBuilder.CreateIndex(
                name: "IX_TareasAccionMejora_AccionMejoraId",
                table: "TareasAccionMejora",
                column: "AccionMejoraId");

            migrationBuilder.CreateIndex(
                name: "IX_TareasAccionMejora_UsuarioAsignadoId",
                table: "TareasAccionMejora",
                column: "UsuarioAsignadoId");

            migrationBuilder.CreateIndex(
                name: "IX_TareasIncidencia_IncidenciaId",
                table: "TareasIncidencia",
                column: "IncidenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_TareasIncidencia_UsuarioAsignadoId",
                table: "TareasIncidencia",
                column: "UsuarioAsignadoId");

            migrationBuilder.CreateIndex(
                name: "IX_TipologiasIncidencia_ProcesoId_Nombre",
                table: "TipologiasIncidencia",
                columns: new[] { "ProcesoId", "Nombre" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TiposAccionMejora_Nombre",
                table: "TiposAccionMejora",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TiposAdjunto_Nombre",
                table: "TiposAdjunto",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TiposCosteNoCalidad_Nombre",
                table: "TiposCosteNoCalidad",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TiposDocumentoReferencia_Nombre",
                table: "TiposDocumentoReferencia",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_DepartamentoId",
                table: "Usuarios",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Login",
                table: "Usuarios",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_SupervisorId",
                table: "Usuarios",
                column: "SupervisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccionesMejora_Incidencias_IncidenciaOrigenId",
                table: "AccionesMejora",
                column: "IncidenciaOrigenId",
                principalTable: "Incidencias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccionesMejora_EstadosAccionMejora_EstadoId",
                table: "AccionesMejora");

            migrationBuilder.DropForeignKey(
                name: "FK_AccionesMejora_Incidencias_IncidenciaOrigenId",
                table: "AccionesMejora");

            migrationBuilder.DropTable(
                name: "ComentariosAccionMejora");

            migrationBuilder.DropTable(
                name: "ComentariosIncidencia");

            migrationBuilder.DropTable(
                name: "ComentariosProyecto");

            migrationBuilder.DropTable(
                name: "CostesNoCalidadIncidencia");

            migrationBuilder.DropTable(
                name: "DetallesIncidencia");

            migrationBuilder.DropTable(
                name: "DocumentosAccionMejora");

            migrationBuilder.DropTable(
                name: "DocumentosIncidencia");

            migrationBuilder.DropTable(
                name: "DocumentosProyecto");

            migrationBuilder.DropTable(
                name: "FasesProyecto");

            migrationBuilder.DropTable(
                name: "ObjetivosProyecto");

            migrationBuilder.DropTable(
                name: "PersonalImplicadoIncidencia");

            migrationBuilder.DropTable(
                name: "PresupuestosProyecto");

            migrationBuilder.DropTable(
                name: "TareasAccionMejora");

            migrationBuilder.DropTable(
                name: "TareasIncidencia");

            migrationBuilder.DropTable(
                name: "TiposCosteNoCalidad");

            migrationBuilder.DropTable(
                name: "EstadosDetalleIncidencia");

            migrationBuilder.DropTable(
                name: "TiposDocumentoReferencia");

            migrationBuilder.DropTable(
                name: "TiposAdjunto");

            migrationBuilder.DropTable(
                name: "EstadosFaseProyecto");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "AreasProyecto");

            migrationBuilder.DropTable(
                name: "EstadosProyecto");

            migrationBuilder.DropTable(
                name: "PrioridadesProyecto");

            migrationBuilder.DropTable(
                name: "EstadosAccionMejora");

            migrationBuilder.DropTable(
                name: "Incidencias");

            migrationBuilder.DropTable(
                name: "AccionesMejora");

            migrationBuilder.DropTable(
                name: "EstadosIncidencia");

            migrationBuilder.DropTable(
                name: "TipologiasIncidencia");

            migrationBuilder.DropTable(
                name: "OrigenesAccionMejora");

            migrationBuilder.DropTable(
                name: "TiposAccionMejora");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Procesos");

            migrationBuilder.DropTable(
                name: "Departamentos");
        }
    }
}
