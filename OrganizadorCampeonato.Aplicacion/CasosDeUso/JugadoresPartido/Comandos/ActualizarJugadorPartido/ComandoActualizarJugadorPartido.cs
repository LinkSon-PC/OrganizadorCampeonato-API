using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.JugadoresPartido.Comandos.ActualizarJugadorPartido
{
    public record ComandoActualizarJugadorPartido : IRequest
    {
        public required Guid Id { get; init; }
        public required int Dorsal { get; init; }
        public bool EsCapitan { get; init; }
        public bool EsTitular { get; init; }
        public bool Jugo { get; init; }
    }
}
