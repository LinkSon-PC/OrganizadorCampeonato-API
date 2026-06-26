using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganizadorCampeonato.Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class AddFasePartidoAndBracketSupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ronda",
                table: "Partidos",
                newName: "Jornada");

            migrationBuilder.AddColumn<string>(
                name: "Grupo",
                table: "TorneoEquipos",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PosicionGrupo",
                table: "TorneoEquipos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Fase",
                table: "Partidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumeroRondaKO",
                table: "Partidos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PartidoOrigenLocalId",
                table: "Partidos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PartidoOrigenVisitanteId",
                table: "Partidos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TorneoEquipos_TorneoId_Grupo",
                table: "TorneoEquipos",
                columns: new[] { "TorneoId", "Grupo" });

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_Fase",
                table: "Partidos",
                column: "Fase");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_PartidoOrigenLocalId",
                table: "Partidos",
                column: "PartidoOrigenLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_PartidoOrigenVisitanteId",
                table: "Partidos",
                column: "PartidoOrigenVisitanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Partidos_Partidos_PartidoOrigenLocalId",
                table: "Partidos",
                column: "PartidoOrigenLocalId",
                principalTable: "Partidos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Partidos_Partidos_PartidoOrigenVisitanteId",
                table: "Partidos",
                column: "PartidoOrigenVisitanteId",
                principalTable: "Partidos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partidos_Partidos_PartidoOrigenLocalId",
                table: "Partidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Partidos_Partidos_PartidoOrigenVisitanteId",
                table: "Partidos");

            migrationBuilder.DropIndex(
                name: "IX_TorneoEquipos_TorneoId_Grupo",
                table: "TorneoEquipos");

            migrationBuilder.DropIndex(
                name: "IX_Partidos_Fase",
                table: "Partidos");

            migrationBuilder.DropIndex(
                name: "IX_Partidos_PartidoOrigenLocalId",
                table: "Partidos");

            migrationBuilder.DropIndex(
                name: "IX_Partidos_PartidoOrigenVisitanteId",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "Grupo",
                table: "TorneoEquipos");

            migrationBuilder.DropColumn(
                name: "PosicionGrupo",
                table: "TorneoEquipos");

            migrationBuilder.DropColumn(
                name: "Fase",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "NumeroRondaKO",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "PartidoOrigenLocalId",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "PartidoOrigenVisitanteId",
                table: "Partidos");

            migrationBuilder.RenameColumn(
                name: "Jornada",
                table: "Partidos",
                newName: "Ronda");
        }
    }
}
