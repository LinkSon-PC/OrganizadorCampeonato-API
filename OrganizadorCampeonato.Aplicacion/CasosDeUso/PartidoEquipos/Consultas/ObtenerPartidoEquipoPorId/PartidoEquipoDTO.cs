using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoEquipos.Consultas.ObtenerPartidoEquipoPorId
{
    public record PartidoEquipoDTO
    {
        public required Guid Id { get; init; }
        public required Guid PartidoId { get; init; }
        public required Guid EquipoId { get; init; }
        public bool EsLocal { get; init; }
        public DateTime FechaCreacion { get; init; }
        public DateTime? UltimaFechaModificacion { get; init; }
    }
}
