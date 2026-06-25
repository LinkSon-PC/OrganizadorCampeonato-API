using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Entrenadores.Consultas.ObtenerEntrenadorPorId
{
    public record ConsultaObtenerEntrenadorPorId : IRequest<EntrenadorDTO>
    {
        public required Guid Id { get; init; }
    }
}
