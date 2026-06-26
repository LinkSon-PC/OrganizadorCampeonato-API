namespace OrganizadorCampeonato.Modelos.Torneos
{
    public record GenerarFixtureGruposDTO
    {
        public required DateTime FechaInicio { get; init; }
        public required string Lugar { get; init; }
    }
}
