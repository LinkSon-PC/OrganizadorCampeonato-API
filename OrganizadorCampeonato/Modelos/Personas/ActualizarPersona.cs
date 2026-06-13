using OrganizadorCampeonato.Dominio.Enum;

namespace OrganizadorCampeonato.Modelos.Personas
{
    public class ActualizarPersona
    {
        public required string Identificacion { get; set; }
        public required string Nombres { get; set; }
        public required string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public required TipoGenero Genero { get; set; }
        public string? Telefono { get; set; }
    }
}
