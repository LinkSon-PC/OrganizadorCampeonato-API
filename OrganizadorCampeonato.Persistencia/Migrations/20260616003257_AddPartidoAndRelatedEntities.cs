using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganizadorCampeonato.Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class AddPartidoAndRelatedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Torneo_Categorias_CategoriaId",
                table: "Torneo");

            migrationBuilder.DropForeignKey(
                name: "FK_TorneoEquipo_Equipos_EquipoId",
                table: "TorneoEquipo");

            migrationBuilder.DropForeignKey(
                name: "FK_TorneoEquipo_Torneo_TorneoId",
                table: "TorneoEquipo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TorneoEquipo",
                table: "TorneoEquipo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Torneo",
                table: "Torneo");

            migrationBuilder.RenameTable(
                name: "TorneoEquipo",
                newName: "TorneoEquipos");

            migrationBuilder.RenameTable(
                name: "Torneo",
                newName: "Torneos");

            migrationBuilder.RenameIndex(
                name: "IX_TorneoEquipo_TorneoId",
                table: "TorneoEquipos",
                newName: "IX_TorneoEquipos_TorneoId");

            migrationBuilder.RenameIndex(
                name: "IX_TorneoEquipo_EquipoId",
                table: "TorneoEquipos",
                newName: "IX_TorneoEquipos_EquipoId");

            migrationBuilder.RenameIndex(
                name: "IX_Torneo_CategoriaId",
                table: "Torneos",
                newName: "IX_Torneos_CategoriaId");

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "TorneoEquipos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInscripcion",
                table: "TorneoEquipos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Posicion",
                table: "TorneoEquipos",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TorneoEquipos",
                table: "TorneoEquipos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Torneos",
                table: "Torneos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Arbitros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimaModificacionPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UltimaFechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arbitros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arbitros_Personas_Id",
                        column: x => x.Id,
                        principalTable: "Personas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EquipoJugadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JugadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaIncorporacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimaModificacionPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UltimaFechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipoJugadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipoJugadores_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipoJugadores_Jugadores_JugadorId",
                        column: x => x.JugadorId,
                        principalTable: "Jugadores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Partidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Lugar = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TorneoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ronda = table.Column<int>(type: "int", nullable: false),
                    Grupo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    PuntosLocal_P1 = table.Column<decimal>(type: "decimal(5,0)", precision: 5, scale: 0, nullable: true),
                    PuntosVisitante_P1 = table.Column<decimal>(type: "decimal(5,0)", precision: 5, scale: 0, nullable: true),
                    PuntosLocal_P2 = table.Column<decimal>(type: "decimal(5,0)", precision: 5, scale: 0, nullable: true),
                    PuntosVisitante_P2 = table.Column<decimal>(type: "decimal(5,0)", precision: 5, scale: 0, nullable: true),
                    PuntosLocal_P3 = table.Column<decimal>(type: "decimal(5,0)", precision: 5, scale: 0, nullable: true),
                    PuntosVisitante_P3 = table.Column<decimal>(type: "decimal(5,0)", precision: 5, scale: 0, nullable: true),
                    PuntosLocal_P4 = table.Column<decimal>(type: "decimal(5,0)", precision: 5, scale: 0, nullable: true),
                    PuntosVisitante_P4 = table.Column<decimal>(type: "decimal(5,0)", precision: 5, scale: 0, nullable: true),
                    PuntosLocal_Prorroga = table.Column<decimal>(type: "decimal(5,0)", precision: 5, scale: 0, nullable: true),
                    PuntosVisitante_Prorroga = table.Column<decimal>(type: "decimal(5,0)", precision: 5, scale: 0, nullable: true),
                    GanadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimaModificacionPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UltimaFechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partidos_Equipos_GanadorId",
                        column: x => x.GanadorId,
                        principalTable: "Equipos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Partidos_Torneos_TorneoId",
                        column: x => x.TorneoId,
                        principalTable: "Torneos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PartidoArbitros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArbitroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimaModificacionPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UltimaFechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartidoArbitros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartidoArbitros_Arbitros_ArbitroId",
                        column: x => x.ArbitroId,
                        principalTable: "Arbitros",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PartidoArbitros_Partidos_PartidoId",
                        column: x => x.PartidoId,
                        principalTable: "Partidos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PartidoEquipos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EsLocal = table.Column<bool>(type: "bit", nullable: false),
                    EsGanador = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimaModificacionPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UltimaFechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartidoEquipos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartidoEquipos_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PartidoEquipos_Partidos_PartidoId",
                        column: x => x.PartidoId,
                        principalTable: "Partidos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_CategoriaId",
                table: "Equipos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_Nombre",
                table: "Equipos",
                column: "Nombre");

            migrationBuilder.CreateIndex(
                name: "IX_EquipoJugadores_EquipoId_JugadorId",
                table: "EquipoJugadores",
                columns: new[] { "EquipoId", "JugadorId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EquipoJugadores_JugadorId",
                table: "EquipoJugadores",
                column: "JugadorId");

            migrationBuilder.CreateIndex(
                name: "IX_PartidoArbitros_ArbitroId",
                table: "PartidoArbitros",
                column: "ArbitroId");

            migrationBuilder.CreateIndex(
                name: "IX_PartidoArbitros_PartidoId",
                table: "PartidoArbitros",
                column: "PartidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PartidoEquipos_EquipoId",
                table: "PartidoEquipos",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_PartidoEquipos_PartidoId_EquipoId",
                table: "PartidoEquipos",
                columns: new[] { "PartidoId", "EquipoId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_Estado",
                table: "Partidos",
                column: "Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_FechaHora",
                table: "Partidos",
                column: "FechaHora");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_GanadorId",
                table: "Partidos",
                column: "GanadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_TorneoId",
                table: "Partidos",
                column: "TorneoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipos_Categorias_CategoriaId",
                table: "Equipos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TorneoEquipos_Equipos_EquipoId",
                table: "TorneoEquipos",
                column: "EquipoId",
                principalTable: "Equipos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TorneoEquipos_Torneos_TorneoId",
                table: "TorneoEquipos",
                column: "TorneoId",
                principalTable: "Torneos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Torneos_Categorias_CategoriaId",
                table: "Torneos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipos_Categorias_CategoriaId",
                table: "Equipos");

            migrationBuilder.DropForeignKey(
                name: "FK_TorneoEquipos_Equipos_EquipoId",
                table: "TorneoEquipos");

            migrationBuilder.DropForeignKey(
                name: "FK_TorneoEquipos_Torneos_TorneoId",
                table: "TorneoEquipos");

            migrationBuilder.DropForeignKey(
                name: "FK_Torneos_Categorias_CategoriaId",
                table: "Torneos");

            migrationBuilder.DropTable(
                name: "EquipoJugadores");

            migrationBuilder.DropTable(
                name: "PartidoArbitros");

            migrationBuilder.DropTable(
                name: "PartidoEquipos");

            migrationBuilder.DropTable(
                name: "Arbitros");

            migrationBuilder.DropTable(
                name: "Partidos");

            migrationBuilder.DropIndex(
                name: "IX_Equipos_CategoriaId",
                table: "Equipos");

            migrationBuilder.DropIndex(
                name: "IX_Equipos_Nombre",
                table: "Equipos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Torneos",
                table: "Torneos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TorneoEquipos",
                table: "TorneoEquipos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "TorneoEquipos");

            migrationBuilder.DropColumn(
                name: "FechaInscripcion",
                table: "TorneoEquipos");

            migrationBuilder.DropColumn(
                name: "Posicion",
                table: "TorneoEquipos");

            migrationBuilder.RenameTable(
                name: "Torneos",
                newName: "Torneo");

            migrationBuilder.RenameTable(
                name: "TorneoEquipos",
                newName: "TorneoEquipo");

            migrationBuilder.RenameIndex(
                name: "IX_Torneos_CategoriaId",
                table: "Torneo",
                newName: "IX_Torneo_CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_TorneoEquipos_TorneoId",
                table: "TorneoEquipo",
                newName: "IX_TorneoEquipo_TorneoId");

            migrationBuilder.RenameIndex(
                name: "IX_TorneoEquipos_EquipoId",
                table: "TorneoEquipo",
                newName: "IX_TorneoEquipo_EquipoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Torneo",
                table: "Torneo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TorneoEquipo",
                table: "TorneoEquipo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Torneo_Categorias_CategoriaId",
                table: "Torneo",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TorneoEquipo_Equipos_EquipoId",
                table: "TorneoEquipo",
                column: "EquipoId",
                principalTable: "Equipos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TorneoEquipo_Torneo_TorneoId",
                table: "TorneoEquipo",
                column: "TorneoId",
                principalTable: "Torneo",
                principalColumn: "Id");
        }
    }
}
