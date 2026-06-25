using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Torneos.Consultas.ObtenerTorneoPorId
{
    public record ConsultaObtenerTorneoPorId : IRequest<TorneoPorIdDTO>
    {
        public required Guid Id { get; init; }
    }
}
