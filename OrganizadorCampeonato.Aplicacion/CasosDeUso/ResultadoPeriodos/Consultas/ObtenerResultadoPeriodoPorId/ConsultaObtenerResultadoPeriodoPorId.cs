using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.ResultadoPeriodos.Consultas.ObtenerResultadoPeriodoPorId
{
    public record ConsultaObtenerResultadoPeriodoPorId : IRequest<ResultadoPeriodoDTO>
    {
        public required Guid Id { get; init; }
    }
}
