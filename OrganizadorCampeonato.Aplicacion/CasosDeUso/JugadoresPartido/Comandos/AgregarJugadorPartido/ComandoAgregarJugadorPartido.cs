using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.JugadoresPartido.Comandos.AgregarJugadorPartido
{
    public record ComandoAgregarJugadorPartido : IRequest<Guid>
    {
        public required Guid PartidoEquipoId { get; init; }
        public required Guid JugadorId { get; init; }
        public required int Dorsal { get; init; }
        public bool EsCapitan { get; init; }
        public bool EsTitular { get; init; }
    }
}
