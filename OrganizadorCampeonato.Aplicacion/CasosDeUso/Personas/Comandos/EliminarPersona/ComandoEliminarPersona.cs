using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Personas.Comandos.EliminarPersona
{
    public record ComandoEliminarPersona : IRequest
    {
        public required Guid Id { get; init; }
    }
}
