namespace OrganizadorCampeonato.Modelos.TorneoEquipos
{
    public record AsignarGrupoEquipoDTO
    {
        public required string Grupo { get; init; }
        public int? PosicionGrupo { get; init; }
    }
}
