using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.ResultadoPeriodos.Comandos.EliminarResultadoPeriodo
{
    public record ComandoEliminarResultadoPeriodo : IRequest
    {
        public required Guid Id { get; init; }
    }
}
