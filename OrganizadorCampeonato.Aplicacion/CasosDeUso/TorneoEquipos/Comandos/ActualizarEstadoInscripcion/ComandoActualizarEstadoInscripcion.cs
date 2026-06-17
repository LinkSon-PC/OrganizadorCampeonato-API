using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Dominio.Enum;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.TorneoEquipos.Comandos.ActualizarEstadoInscripcion
{
    public record ComandoActualizarEstadoInscripcion : IRequest
    {
        public required Guid TorneoId { get; init; }
        public required Guid EquipoId { get; init; }
        public required EstadoInscripcion Estado { get; init; }
        public int? Posicion { get; init; }
    }
}
