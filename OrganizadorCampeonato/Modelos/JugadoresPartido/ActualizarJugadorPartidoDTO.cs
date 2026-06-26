namespace OrganizadorCampeonato.Modelos.JugadoresPartido
{
    public record ActualizarJugadorPartidoDTO
    {
        public required int Dorsal { get; init; }
        public bool EsCapitan { get; init; }
        public bool EsTitular { get; init; }
        public bool Jugo { get; init; }
    }
}
