using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganizadorCampeonato.Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class AddSegundoTiempoExcedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PuntosLocal_Prorroga2",
                table: "Partidos",
                type: "decimal(5,0)",
                precision: 5,
                scale: 0,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PuntosVisitante_Prorroga2",
                table: "Partidos",
                type: "decimal(5,0)",
                precision: 5,
                scale: 0,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PuntosLocal_Prorroga2",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "PuntosVisitante_Prorroga2",
                table: "Partidos");
        }
    }
}
