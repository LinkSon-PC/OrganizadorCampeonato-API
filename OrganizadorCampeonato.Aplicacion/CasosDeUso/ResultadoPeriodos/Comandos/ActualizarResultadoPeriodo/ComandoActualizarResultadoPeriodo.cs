using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Dominio.Enum;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.ResultadoPeriodos.Comandos.ActualizarResultadoPeriodo
{
    public record ComandoActualizarResultadoPeriodo : IRequest
    {
        public required Guid Id { get; init; }
        public required Guid PartidoId { get; init; }
        public required TipoPeriodo Periodo { get; init; }
        public required int NumeroProrroga { get; init; }
        public required int PuntosLocal { get; init; }
        public required int PuntosVisitante { get; init; }
    }
}
