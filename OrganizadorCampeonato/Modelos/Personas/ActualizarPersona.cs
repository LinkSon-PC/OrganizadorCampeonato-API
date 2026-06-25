using OrganizadorCampeonato.Dominio.Enum;

namespace OrganizadorCampeonato.Modelos.Personas
{
    public record ActualizarPersona
    {
        public required string Identificacion { get; init; }
        public required string Nombres { get; init; }
        public required string Apellidos { get; init; }
        public DateTime FechaNacimiento { get; init; }
        public required TipoGenero Genero { get; init; }
        public string? Telefono { get; init; }
    }
}
