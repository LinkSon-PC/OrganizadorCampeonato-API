using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Enum;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.TorneoEquipos.Consultas.ObtenerTorneoEquipoPorId
{
    public class CasoDeUsoObtenerTorneoEquipoPorId : IRequestHandler<ConsultaObtenerTorneoEquipoPorId, TorneoEquipoPorIdDTO>
    {
        private readonly IRepositorioTorneoEquipo repositorio;

        public CasoDeUsoObtenerTorneoEquipoPorId(IRepositorioTorneoEquipo repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<TorneoEquipoPorIdDTO> Handle(ConsultaObtenerTorneoEquipoPorId request)
        {
            var entity = await repositorio.ObtenerPorId(request.Id);
            if (entity is null)
                throw new ExcepcionDeValidacion("No se encontro la inscripcion del equipo");

            return entity.ADto();
        }
    }
}
