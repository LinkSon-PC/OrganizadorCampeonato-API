using OrganizadorCampeonato.Dominio.Enum;

namespace OrganizadorCampeonato.Modelos.Torneos
{
    public record ActualizarTorneoDTO
    {
        public required string Nombre { get; init; }
        public required string Lugar { get; init; }
        public string? Descripcion { get; init; }
        public Guid? CategoriaId { get; init; }
        public required FormatoTorneo Formato { get; init; }
        public required DateTime FechaInicio { get; init; }
        public required DateTime FechaFin { get; init; }
    }
}
