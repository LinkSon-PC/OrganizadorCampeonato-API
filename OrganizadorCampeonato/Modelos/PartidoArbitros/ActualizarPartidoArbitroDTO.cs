namespace OrganizadorCampeonato.Modelos.PartidoArbitros
{
    public record ActualizarPartidoArbitroDTO
    {
        public required Guid PartidoId { get; init; }
        public required Guid ArbitroId { get; init; }
        public string? Rol { get; init; }
    }
}
