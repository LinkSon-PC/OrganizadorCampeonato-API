using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Equipos.Consultas.ObtenerEquipoPorId
{
    public class CasoDeUsoObtenerPorId : IRequestHandler<ConsultaObtenerEquipoPorId, EquipoDTO>
    {
        private readonly IRepositorioEquipo repositorio;

        public CasoDeUsoObtenerPorId(IRepositorioEquipo repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<EquipoDTO> Handle(ConsultaObtenerEquipoPorId request)
        {
            var equipo = await repositorio.ObtenerPorId(request.Id);
            if (equipo is null)
                throw new ExcepcionDeValidacion("No se encontró equipo");

            return equipo.ADto();
        }
    }
}
