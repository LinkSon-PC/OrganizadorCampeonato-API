using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using System;
using System.Collections.Generic;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.EquipoJugadores.Consultas.ObtenerJugadoresPorEquipo
{
    public record ConsultaObtenerJugadoresPorEquipo : IRequest<List<JugadorEquipoDTO>>
    {
        public required Guid EquipoId { get; init; }
    }
}
