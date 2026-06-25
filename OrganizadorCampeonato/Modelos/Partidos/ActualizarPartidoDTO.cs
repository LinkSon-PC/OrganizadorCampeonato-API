namespace OrganizadorCampeonato.Modelos.Partidos
{
    public record ActualizarPartidoDTO
    {
        public required DateTime FechaHora { get; init; }
        public required string Lugar { get; init; }
        public required Guid TorneoId { get; init; }
        public required int Ronda { get; init; }
        public string? Grupo { get; init; }
    }
}
