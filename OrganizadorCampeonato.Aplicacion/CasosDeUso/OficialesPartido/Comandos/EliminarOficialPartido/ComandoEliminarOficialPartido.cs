using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.OficialesPartido.Comandos.EliminarOficialPartido
{
    public record ComandoEliminarOficialPartido : IRequest
    {
        public required Guid Id { get; init; }
    }
}
