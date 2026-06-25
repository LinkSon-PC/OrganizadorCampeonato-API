namespace OrganizadorCampeonato.Modelos.PartidoEquipos
{
    public record MarcarGanadorDTO
    {
        public required Guid PartidoId { get; init; }
        public required Guid EquipoId { get; init; }
        public required bool EsLocal { get; init; }
        public required bool EsGanador { get; init; }
    }
}
