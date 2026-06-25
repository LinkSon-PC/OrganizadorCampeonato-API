using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganizadorCampeonato.Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class RefactorFibaScoring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partidos_Equipos_GanadorId",
                table: "Partidos");

            migrationBuilder.DropForeignKey(
                name: "FK_ResultadosPeriodos_Equipos_EquipoId",
                table: "ResultadosPeriodos");

            migrationBuilder.DropIndex(
                name: "IX_ResultadosPeriodos_EquipoId",
                table: "ResultadosPeriodos");

            migrationBuilder.DropIndex(
                name: "IX_ResultadosPeriodos_PartidoId_Periodo",
                table: "ResultadosPeriodos");

            migrationBuilder.DropIndex(
                name: "IX_Partidos_GanadorId",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "EquipoId",
                table: "ResultadosPeriodos");

            migrationBuilder.DropColumn(
                name: "GanadorId",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "PuntosLocal_P1",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "PuntosLocal_P2",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "PuntosLocal_P3",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "PuntosLocal_P4",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "PuntosLocal_Prorroga",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "PuntosLocal_Prorroga2",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "PuntosVisitante_P1",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "PuntosVisitante_P2",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "PuntosVisitante_P3",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "PuntosVisitante_P4",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "PuntosVisitante_Prorroga",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "PuntosVisitante_Prorroga2",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "EsGanador",
                table: "PartidoEquipos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaFechaModificacion",
                table: "Torneos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaFechaModificacion",
                table: "TorneoEquipos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaFechaModificacion",
                table: "ResultadosPeriodos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumeroProrroga",
                table: "ResultadosPeriodos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PuntosLocal",
                table: "ResultadosPeriodos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PuntosVisitante",
                table: "ResultadosPeriodos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaFechaModificacion",
                table: "Personas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaFechaModificacion",
                table: "Partidos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaFechaModificacion",
                table: "PartidoEquipos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaFechaModificacion",
                table: "PartidoArbitros",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaFechaModificacion",
                table: "Jugadores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaFechaModificacion",
                table: "Equipos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaFechaModificacion",
                table: "EquipoJugadores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaFechaModificacion",
                table: "Entrenadores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaFechaModificacion",
                table: "Categorias",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaFechaModificacion",
                table: "Arbitros",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResultadosPeriodos_PartidoId_Periodo_NumeroProrroga",
                table: "ResultadosPeriodos",
                columns: new[] { "PartidoId", "Periodo", "NumeroProrroga" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ResultadosPeriodos_PartidoId_Periodo_NumeroProrroga",
                table: "ResultadosPeriodos");

            migrationBuilder.DropColumn(
                name: "NumeroProrroga",
                table: "ResultadosPeriodos");

            migrationBuilder.DropColumn(
                name: "PuntosLocal",
                table: "ResultadosPeriodos");

            migrationBuilder.DropColumn(
                name: "PuntosVisitante",
                table: "ResultadosPeriodos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaFechaModificacion",
                table: "Torneos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaFechaModificacion",
                table: "TorneoEquipos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaFechaModificacion",
                table: "ResultadosPeriodos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "EquipoId",
                table: "ResultadosPeriodos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaFechaModificacion",
                table: "Personas",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaFechaModificacion",
                table: "Partidos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<Guid>(
                name: "GanadorId",
                table: "Partidos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PuntosLocal_P1",
                table: "Partidos",
                type: "decimal(5,0)",
                precision: 5,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PuntosLocal_P2",
                table: "Partidos",
                type: "decimal(5,0)",
                precision: 5,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PuntosLocal_P3",
                table: "Partidos",
                type: "decimal(5,0)",
                precision: 5,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PuntosLocal_P4",
                table: "Partidos",
                type: "decimal(5,0)",
                precision: 5,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PuntosLocal_Prorroga",
                table: "Partidos",
                type: "decimal(5,0)",
                precision: 5,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PuntosLocal_Prorroga2",
                table: "Partidos",
                type: "decimal(5,0)",
                precision: 5,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PuntosVisitante_P1",
                table: "Partidos",
                type: "decimal(5,0)",
                precision: 5,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PuntosVisitante_P2",
                table: "Partidos",
                type: "decimal(5,0)",
                precision: 5,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PuntosVisitante_P3",
                table: "Partidos",
                type: "decimal(5,0)",
                precision: 5,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PuntosVisitante_P4",
                table: "Partidos",
                type: "decimal(5,0)",
                precision: 5,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PuntosVisitante_Prorroga",
                table: "Partidos",
                type: "decimal(5,0)",
                precision: 5,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PuntosVisitante_Prorroga2",
                table: "Partidos",
                type: "decimal(5,0)",
                precision: 5,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaFechaModificacion",
                table: "PartidoEquipos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<bool>(
                name: "EsGanador",
                table: "PartidoEquipos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaFechaModificacion",
                table: "PartidoArbitros",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaFechaModificacion",
                table: "Jugadores",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaFechaModificacion",
                table: "Equipos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaFechaModificacion",
                table: "EquipoJugadores",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaFechaModificacion",
                table: "Entrenadores",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaFechaModificacion",
                table: "Categorias",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaFechaModificacion",
                table: "Arbitros",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_ResultadosPeriodos_EquipoId",
                table: "ResultadosPeriodos",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultadosPeriodos_PartidoId_Periodo",
                table: "ResultadosPeriodos",
                columns: new[] { "PartidoId", "Periodo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_GanadorId",
                table: "Partidos",
                column: "GanadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partidos_Equipos_GanadorId",
                table: "Partidos",
                column: "GanadorId",
                principalTable: "Equipos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultadosPeriodos_Equipos_EquipoId",
                table: "ResultadosPeriodos",
                column: "EquipoId",
                principalTable: "Equipos",
                principalColumn: "Id");
        }
    }
}
