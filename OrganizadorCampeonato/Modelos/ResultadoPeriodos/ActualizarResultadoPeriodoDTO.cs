using OrganizadorCampeonato.Dominio.Enum;

namespace OrganizadorCampeonato.Modelos.ResultadoPeriodos
{
    public record ActualizarResultadoPeriodoDTO
    {
        public required Guid PartidoId { get; init; }
        public required TipoPeriodo Periodo { get; init; }
        public required Guid EquipoId { get; init; }
    }
}
