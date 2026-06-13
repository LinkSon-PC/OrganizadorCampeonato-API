using OrganizadorCampeonato.Dominio.Enum;

namespace OrganizadorCampeonato.Modelos.Equipos
{
    public record ActualizarEquipoDTO
    {
        public required string Nombre { get; init; }
        public Guid? EntrenadorId { get; init; }
        public Guid? CategoriaId { get; private set; }
    }
}
