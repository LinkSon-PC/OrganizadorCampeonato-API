using OrganizadorCampeonato.Dominio.Enum;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.TorneoEquipos.Consultas.ObtenerEquiposPorTorneo
{
    public record TorneoEquipoDTO
    {
        public required Guid EquipoId { get; init; }
        public required string NombreEquipo { get; init; }
        public required DateTime FechaInscripcion { get; init; }
        public required int? Posicion { get; init; }
        public string? Grupo { get; init; }
        public int? PosicionGrupo { get; init; }
        public required EstadoInscripcion Estado { get; init; }
    }
}
