namespace OrganizadorCampeonato.Modelos.Torneos
{
    public record GenerarLlaveEliminatoriaDTO
    {
        public required DateTime FechaInicio { get; init; }
        public required string Lugar { get; init; }
    }
}
