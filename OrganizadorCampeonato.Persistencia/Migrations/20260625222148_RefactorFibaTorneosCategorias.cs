using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganizadorCampeonato.Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class RefactorFibaTorneosCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TorneoEquipos_TorneoId",
                table: "TorneoEquipos");

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Torneos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Torneos_FechaInicio",
                table: "Torneos",
                column: "FechaInicio");

            migrationBuilder.CreateIndex(
                name: "IX_Torneos_Formato",
                table: "Torneos",
                column: "Formato");

            migrationBuilder.CreateIndex(
                name: "IX_TorneoEquipos_TorneoId_EquipoId",
                table: "TorneoEquipos",
                columns: new[] { "TorneoId", "EquipoId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_Tipo_Genero",
                table: "Categorias",
                columns: new[] { "Tipo", "Genero" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Torneos_FechaInicio",
                table: "Torneos");

            migrationBuilder.DropIndex(
                name: "IX_Torneos_Formato",
                table: "Torneos");

            migrationBuilder.DropIndex(
                name: "IX_TorneoEquipos_TorneoId_EquipoId",
                table: "TorneoEquipos");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_Tipo_Genero",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Torneos");

            migrationBuilder.CreateIndex(
                name: "IX_TorneoEquipos_TorneoId",
                table: "TorneoEquipos",
                column: "TorneoId");
        }
    }
}
