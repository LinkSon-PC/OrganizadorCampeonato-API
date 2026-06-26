using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Dominio.Enum;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.OficialesPartido.Comandos.AgregarOficialPartido
{
    public record ComandoAgregarOficialPartido : IRequest<Guid>
    {
        public required Guid PartidoId { get; init; }
        public required Guid ArbitroId { get; init; }
        public required TipoOficial Rol { get; init; }
    }
}
