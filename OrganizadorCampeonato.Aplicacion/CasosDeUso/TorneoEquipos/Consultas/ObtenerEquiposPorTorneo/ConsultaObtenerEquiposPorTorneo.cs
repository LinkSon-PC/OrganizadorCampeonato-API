using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.TorneoEquipos.Consultas.ObtenerEquiposPorTorneo
{
    public record ConsultaObtenerEquiposPorTorneo : IRequest<List<TorneoEquipoDTO>>
    {
        public required Guid TorneoId { get; init; }
    }
}
