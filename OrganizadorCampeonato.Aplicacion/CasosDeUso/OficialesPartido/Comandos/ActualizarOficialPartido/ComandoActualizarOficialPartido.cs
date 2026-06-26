using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Dominio.Enum;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.OficialesPartido.Comandos.ActualizarOficialPartido
{
    public record ComandoActualizarOficialPartido : IRequest
    {
        public required Guid Id { get; init; }
        public required Guid PartidoId { get; init; }
        public required Guid ArbitroId { get; init; }
        public required TipoOficial Rol { get; init; }
    }
}
