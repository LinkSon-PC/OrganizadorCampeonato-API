using OrganizadorCampeonato.Dominio.Enum;

namespace OrganizadorCampeonato.Modelos.Partidos
{
    public record AgregarPartidoDTO
    {
        public required DateTime FechaHora { get; init; }
        public required string Lugar { get; init; }
        public required Guid TorneoId { get; init; }
        public required FasePartido Fase { get; init; }
        public required int Jornada { get; init; }
        public string? Grupo { get; init; }
        public int? NumeroRondaKO { get; init; }
        public Guid? PartidoOrigenLocalId { get; init; }
        public Guid? PartidoOrigenVisitanteId { get; init; }
    }
}
