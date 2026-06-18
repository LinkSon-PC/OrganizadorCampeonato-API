using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.EquipoJugadores.Consultas.ObtenerJugadoresPorEquipo
{
    public class CasoDeUsoObtenerJugadoresPorEquipo : IRequestHandler<ConsultaObtenerJugadoresPorEquipo, List<JugadorEquipoDTO>>
    {
        private readonly IRepositorioEquipoJugador repositorioEquipoJugador;

        public CasoDeUsoObtenerJugadoresPorEquipo(IRepositorioEquipoJugador repositorioEquipoJugador)
        {
            this.repositorioEquipoJugador = repositorioEquipoJugador;
        }

        public async Task<List<JugadorEquipoDTO>> Handle(ConsultaObtenerJugadoresPorEquipo request)
        {
            var equipoJugadores = await repositorioEquipoJugador.ObtenerPorEquipo(request.EquipoId);
            return equipoJugadores.Select(ej => ej.ADto()).ToList();
        }
    }
}
