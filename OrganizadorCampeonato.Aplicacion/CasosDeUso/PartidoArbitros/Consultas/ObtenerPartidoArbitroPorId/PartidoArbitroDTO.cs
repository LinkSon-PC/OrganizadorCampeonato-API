using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoArbitros.Consultas.ObtenerPartidoArbitroPorId
{
    public record PartidoArbitroDTO
    {
        public required Guid Id { get; init; }
        public required Guid PartidoId { get; init; }
        public required Guid ArbitroId { get; init; }
        public string? Rol { get; init; }
        public DateTime FechaCreacion { get; init; }
        public DateTime? UltimaFechaModificacion { get; init; }
    }
}
