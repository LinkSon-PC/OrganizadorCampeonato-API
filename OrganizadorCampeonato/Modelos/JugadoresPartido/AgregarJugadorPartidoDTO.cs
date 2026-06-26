namespace OrganizadorCampeonato.Modelos.JugadoresPartido
{
    public record AgregarJugadorPartidoDTO
    {
        public required Guid PartidoEquipoId { get; init; }
        public required Guid JugadorId { get; init; }
        public required int Dorsal { get; init; }
        public bool EsCapitan { get; init; }
        public bool EsTitular { get; init; }
    }
}
