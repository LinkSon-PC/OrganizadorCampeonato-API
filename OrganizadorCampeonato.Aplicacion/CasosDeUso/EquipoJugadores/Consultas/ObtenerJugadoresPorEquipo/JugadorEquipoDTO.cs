using OrganizadorCampeonato.Dominio.Enum;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.EquipoJugadores.Consultas.ObtenerJugadoresPorEquipo
{
    public record JugadorEquipoDTO
    {
        public required Guid InscripcionId { get; init; }
        public required Guid JugadorId { get; init; }
        public required bool EstaActivo { get; init; }
        public required string Nombres { get; init; }
        public required string Apellidos { get; init; }
        public required TipoGenero Genero { get; init; }
    }
}
