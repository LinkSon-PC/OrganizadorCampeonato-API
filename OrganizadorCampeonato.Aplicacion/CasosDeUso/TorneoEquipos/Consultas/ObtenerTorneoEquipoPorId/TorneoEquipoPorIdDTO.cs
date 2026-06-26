using OrganizadorCampeonato.Dominio.Enum;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.TorneoEquipos.Consultas.ObtenerTorneoEquipoPorId
{
    public record TorneoEquipoPorIdDTO
    {
        public required Guid Id { get; init; }
        public required Guid TorneoId { get; init; }
        public required Guid EquipoId { get; init; }
        public required string NombreEquipo { get; init; }
        public DateTime FechaInscripcion { get; init; }
        public required EstadoInscripcion Estado { get; init; }
        public int? Posicion { get; init; }
        public string? Grupo { get; init; }
        public int? PosicionGrupo { get; init; }
        public DateTime FechaCreacion { get; init; }
        public DateTime? UltimaFechaModificacion { get; init; }
    }
}
