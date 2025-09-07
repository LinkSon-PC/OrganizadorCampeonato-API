using OrganizadorCampeonato.Dominio.Enum;

namespace OrganizadorCampeonato.Modelos.Jugadores
{
    public record AgregarEntrenadorDTO
    {
        public required string Identificacion { get; set; }
        public required string Nombres { get; set; }
        public required string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? Telefono { get; set; }
        public required TipoGenero Genero { get; set; }
    }
}
