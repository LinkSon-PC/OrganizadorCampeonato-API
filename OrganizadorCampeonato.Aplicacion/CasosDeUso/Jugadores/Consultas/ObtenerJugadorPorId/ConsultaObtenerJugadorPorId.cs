using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Jugadores.Consultas.ObtenerJugadorPorId
{
    public record ConsultaObtenerJugadorPorId : IRequest<JugadorPorIdDTO>
    {
        public required Guid Id { get; init; }
    }
}
