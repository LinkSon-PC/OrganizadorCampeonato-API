namespace OrganizadorCampeonato.Modelos.TorneoEquipos
{
    public record InscribirEquipoDTO
    {
        public required Guid TorneoId { get; init; }
        public required Guid EquipoId { get; init; }
        public string? Grupo { get; init; }
        public int? PosicionGrupo { get; init; }
    }
}
