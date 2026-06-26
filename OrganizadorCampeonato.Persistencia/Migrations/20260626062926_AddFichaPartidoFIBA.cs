using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganizadorCampeonato.Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class AddFichaPartidoFIBA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartidoArbitros");

            migrationBuilder.CreateTable(
                name: "JugadoresPartido",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartidoEquipoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JugadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Dorsal = table.Column<int>(type: "int", nullable: false),
                    EsCapitan = table.Column<bool>(type: "bit", nullable: false),
                    EsTitular = table.Column<bool>(type: "bit", nullable: false),
                    Jugo = table.Column<bool>(type: "bit", nullable: false),
                    PartidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimaModificacionPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UltimaFechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JugadoresPartido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JugadoresPartido_Jugadores_JugadorId",
                        column: x => x.JugadorId,
                        principalTable: "Jugadores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JugadoresPartido_PartidoEquipos_PartidoEquipoId",
                        column: x => x.PartidoEquipoId,
                        principalTable: "PartidoEquipos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JugadoresPartido_Partidos_PartidoId",
                        column: x => x.PartidoId,
                        principalTable: "Partidos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OficialesPartido",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArbitroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimaModificacionPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UltimaFechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OficialesPartido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OficialesPartido_Arbitros_ArbitroId",
                        column: x => x.ArbitroId,
                        principalTable: "Arbitros",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OficialesPartido_Partidos_PartidoId",
                        column: x => x.PartidoId,
                        principalTable: "Partidos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TiemposMuertos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Periodo = table.Column<int>(type: "int", nullable: false),
                    Minuto = table.Column<int>(type: "int", nullable: false),
                    NumeroTimeout = table.Column<int>(type: "int", nullable: false),
                    EsPrimeraMitad = table.Column<bool>(type: "bit", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimaModificacionPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UltimaFechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiemposMuertos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiemposMuertos_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TiemposMuertos_Partidos_PartidoId",
                        column: x => x.PartidoId,
                        principalTable: "Partidos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Faltas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JugadorPartidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Periodo = table.Column<int>(type: "int", nullable: false),
                    Minuto = table.Column<int>(type: "int", nullable: false),
                    NumeroFalta = table.Column<int>(type: "int", nullable: false),
                    PartidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimaModificacionPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UltimaFechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faltas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faltas_JugadoresPartido_JugadorPartidoId",
                        column: x => x.JugadorPartidoId,
                        principalTable: "JugadoresPartido",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Faltas_Partidos_PartidoId",
                        column: x => x.PartidoId,
                        principalTable: "Partidos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faltas_JugadorPartidoId_Periodo",
                table: "Faltas",
                columns: new[] { "JugadorPartidoId", "Periodo" });

            migrationBuilder.CreateIndex(
                name: "IX_Faltas_PartidoId",
                table: "Faltas",
                column: "PartidoId");

            migrationBuilder.CreateIndex(
                name: "IX_JugadoresPartido_JugadorId",
                table: "JugadoresPartido",
                column: "JugadorId");

            migrationBuilder.CreateIndex(
                name: "IX_JugadoresPartido_PartidoEquipoId_JugadorId",
                table: "JugadoresPartido",
                columns: new[] { "PartidoEquipoId", "JugadorId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JugadoresPartido_PartidoId",
                table: "JugadoresPartido",
                column: "PartidoId");

            migrationBuilder.CreateIndex(
                name: "IX_OficialesPartido_ArbitroId",
                table: "OficialesPartido",
                column: "ArbitroId");

            migrationBuilder.CreateIndex(
                name: "IX_OficialesPartido_PartidoId_Rol",
                table: "OficialesPartido",
                columns: new[] { "PartidoId", "Rol" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TiemposMuertos_EquipoId",
                table: "TiemposMuertos",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_TiemposMuertos_PartidoId_EquipoId_EsPrimeraMitad",
                table: "TiemposMuertos",
                columns: new[] { "PartidoId", "EquipoId", "EsPrimeraMitad" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faltas");

            migrationBuilder.DropTable(
                name: "OficialesPartido");

            migrationBuilder.DropTable(
                name: "TiemposMuertos");

            migrationBuilder.DropTable(
                name: "JugadoresPartido");

            migrationBuilder.CreateTable(
                name: "PartidoArbitros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArbitroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UltimaFechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimaModificacionPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_PartidoArbitros_ArbitroId",
                table: "PartidoArbitros",
                column: "ArbitroId");

            migrationBuilder.CreateIndex(
                name: "IX_PartidoArbitros_PartidoId",
                table: "PartidoArbitros",
                column: "PartidoId");
        }
    }
}
