using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.TorneoEquipos.Consultas.ObtenerEquiposPorTorneo
{
    public class CasoDeUsoObtenerEquiposPorTorneo : IRequestHandler<ConsultaObtenerEquiposPorTorneo, List<TorneoEquipoDTO>>
    {
        private readonly IRepositorioTorneoEquipo repositorioTorneoEquipo;

        public CasoDeUsoObtenerEquiposPorTorneo(IRepositorioTorneoEquipo repositorioTorneoEquipo)
        {
            this.repositorioTorneoEquipo = repositorioTorneoEquipo;
        }

        public async Task<List<TorneoEquipoDTO>> Handle(ConsultaObtenerEquiposPorTorneo request)
        {
            var equipos = await repositorioTorneoEquipo.ObtenerTodosEquipoTorneo(request.TorneoId);
            return equipos.Select(te => te.ADto()).ToList();
        }
    }
}
