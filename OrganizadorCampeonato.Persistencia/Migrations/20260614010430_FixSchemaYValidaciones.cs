using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganizadorCampeonato.Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class FixSchemaYValidaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TorneoEquipo_Equipos_TorneoId",
                table: "TorneoEquipo");

            migrationBuilder.AlterColumn<string>(
                name: "Lugar",
                table: "Torneo",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Torneo",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoriaId",
                table: "Torneo",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TorneoEquipo_EquipoId",
                table: "TorneoEquipo",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Identificacion",
                table: "Personas",
                column: "Identificacion",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TorneoEquipo_Equipos_EquipoId",
                table: "TorneoEquipo",
                column: "EquipoId",
                principalTable: "Equipos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TorneoEquipo_Equipos_EquipoId",
                table: "TorneoEquipo");

            migrationBuilder.DropIndex(
                name: "IX_TorneoEquipo_EquipoId",
                table: "TorneoEquipo");

            migrationBuilder.DropIndex(
                name: "IX_Personas_Identificacion",
                table: "Personas");

            migrationBuilder.AlterColumn<string>(
                name: "Lugar",
                table: "Torneo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Torneo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoriaId",
                table: "Torneo",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_TorneoEquipo_Equipos_TorneoId",
                table: "TorneoEquipo",
                column: "TorneoId",
                principalTable: "Equipos",
                principalColumn: "Id");
        }
    }
}
