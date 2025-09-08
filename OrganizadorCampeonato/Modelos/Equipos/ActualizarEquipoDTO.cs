namespace OrganizadorCampeonato.Modelos.Equipos
{
    public record ActualizarEquipoDTO
    {
        public required string Nombre { get; init; }
        public Guid? EntrenadorId { get; init; }
    }
}
