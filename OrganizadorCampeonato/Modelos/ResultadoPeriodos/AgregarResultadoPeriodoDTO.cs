using OrganizadorCampeonato.Dominio.Enum;

namespace OrganizadorCampeonato.Modelos.ResultadoPeriodos
{
    public record AgregarResultadoPeriodoDTO
    {
        public required Guid PartidoId { get; init; }
        public required TipoPeriodo Periodo { get; init; }
        public required int NumeroProrroga { get; init; }
        public required int PuntosLocal { get; init; }
        public required int PuntosVisitante { get; init; }
    }
}
