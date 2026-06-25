namespace OrganizadorCampeonato.Modelos.Partidos
{
    public record CompletarPartidoDTO
    {
        public required DateTime FechaHora { get; init; }
        public required string Lugar { get; init; }
        public required Guid TorneoId { get; init; }
        public required int Ronda { get; init; }
        public string? Grupo { get; init; }
        public required Guid GanadorId { get; init; }
        public decimal? PuntosLocal_P1 { get; init; }
        public decimal? PuntosVisitante_P1 { get; init; }
        public decimal? PuntosLocal_P2 { get; init; }
        public decimal? PuntosVisitante_P2 { get; init; }
        public decimal? PuntosLocal_P3 { get; init; }
        public decimal? PuntosVisitante_P3 { get; init; }
        public decimal? PuntosLocal_P4 { get; init; }
        public decimal? PuntosVisitante_P4 { get; init; }
        public decimal? PuntosLocal_Prorroga { get; init; }
        public decimal? PuntosVisitante_Prorroga { get; init; }
        public decimal? PuntosLocal_Prorroga2 { get; init; }
        public decimal? PuntosVisitante_Prorroga2 { get; init; }
    }
}
