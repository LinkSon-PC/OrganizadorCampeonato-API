namespace OrganizadorCampeonato.Modelos.PartidoEquipos
{
    public record AgregarPartidoEquipoDTO
    {
        public required Guid PartidoId { get; init; }
        public required Guid EquipoId { get; init; }
        public required bool EsLocal { get; init; }
    }
}
