using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.OficialesPartido.Consultas.ObtenerOficialPartidoPorId
{
    public record ConsultaObtenerOficialPartidoPorId : IRequest<OficialPartidoDTO>
    {
        public required Guid Id { get; init; }
    }
}
