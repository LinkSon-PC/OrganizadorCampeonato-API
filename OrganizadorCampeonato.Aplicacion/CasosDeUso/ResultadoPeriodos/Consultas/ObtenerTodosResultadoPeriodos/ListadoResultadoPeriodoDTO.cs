using OrganizadorCampeonato.Dominio.Enum;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.ResultadoPeriodos.Consultas.ObtenerTodosResultadoPeriodos
{
    public record ListadoResultadoPeriodoDTO
    {
        public required Guid Id { get; init; }
        public required Guid PartidoId { get; init; }
        public required TipoPeriodo Periodo { get; init; }
        public required Guid EquipoId { get; init; }
        public DateTime FechaCreacion { get; init; }
    }
}
