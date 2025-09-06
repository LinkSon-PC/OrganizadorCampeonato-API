namespace OrganizadorCampeonato.Modelos.Jugadores
{
    public class AgregarJugadorDTO
    {
        public required string Identificacion { get; set; }
        public required string Nombres { get; set; }
        public required string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? Telefono { get; set; }
    }
}
