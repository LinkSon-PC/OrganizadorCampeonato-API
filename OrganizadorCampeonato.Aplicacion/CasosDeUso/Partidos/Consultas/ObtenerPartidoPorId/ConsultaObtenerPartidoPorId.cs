using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Partidos.Consultas.ObtenerPartidoPorId
{
    public record ConsultaObtenerPartidoPorId : IRequest<PartidoDTO>
    {
        public required Guid Id { get; init; }
    }
}
