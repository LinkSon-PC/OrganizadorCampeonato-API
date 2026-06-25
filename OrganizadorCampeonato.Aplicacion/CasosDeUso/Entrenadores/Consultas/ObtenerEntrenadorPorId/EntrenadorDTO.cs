using OrganizadorCampeonato.Dominio.Enum;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Entrenadores.Consultas.ObtenerEntrenadorPorId
{
    public record EntrenadorDTO
    {
        public required Guid Id { get; init; }
        public required string Identificacion { get; init; }
        public required string Nombres { get; init; }
        public required string Apellidos { get; init; }
        public required TipoGenero Genero { get; init; }
        public DateTime FechaNacimiento { get; init; }
        public string? Telefono { get; init; }
        public DateTime FechaCreacion { get; init; }
        public DateTime? UltimaFechaModificacion { get; init; }
    }
}
