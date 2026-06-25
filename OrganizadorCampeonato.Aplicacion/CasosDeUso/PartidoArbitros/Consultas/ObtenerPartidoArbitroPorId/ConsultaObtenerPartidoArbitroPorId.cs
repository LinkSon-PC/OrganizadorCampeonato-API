using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoArbitros.Consultas.ObtenerPartidoArbitroPorId
{
    public record ConsultaObtenerPartidoArbitroPorId : IRequest<PartidoArbitroDTO>
    {
        public required Guid Id { get; init; }
    }
}
