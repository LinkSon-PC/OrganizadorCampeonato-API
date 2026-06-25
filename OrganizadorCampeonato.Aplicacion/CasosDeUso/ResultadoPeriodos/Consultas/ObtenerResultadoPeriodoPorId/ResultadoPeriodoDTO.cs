using OrganizadorCampeonato.Dominio.Enum;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.ResultadoPeriodos.Consultas.ObtenerResultadoPeriodoPorId
{
    public record ResultadoPeriodoDTO
    {
        public required Guid Id { get; init; }
        public required Guid PartidoId { get; init; }
        public required TipoPeriodo Periodo { get; init; }
        public required int NumeroProrroga { get; init; }
        public required int PuntosLocal { get; init; }
        public required int PuntosVisitante { get; init; }
        public DateTime FechaCreacion { get; init; }
        public DateTime? UltimaFechaModificacion { get; init; }
    }
}
