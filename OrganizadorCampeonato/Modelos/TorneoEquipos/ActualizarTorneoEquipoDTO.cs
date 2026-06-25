namespace OrganizadorCampeonato.Modelos.TorneoEquipos
{
    public record ActualizarTorneoEquipoDTO
    {
        public required Guid TorneoId { get; init; }
        public required Guid EquipoId { get; init; }
        public int? Posicion { get; init; }
    }
}
