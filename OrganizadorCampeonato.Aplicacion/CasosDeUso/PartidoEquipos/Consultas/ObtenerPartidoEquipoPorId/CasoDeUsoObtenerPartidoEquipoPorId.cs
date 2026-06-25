using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoEquipos.Consultas.ObtenerPartidoEquipoPorId
{
    public class CasoDeUsoObtenerPartidoEquipoPorId : IRequestHandler<ConsultaObtenerPartidoEquipoPorId, PartidoEquipoDTO>
    {
        private readonly IRepositorioPartidoEquipo repositorio;

        public CasoDeUsoObtenerPartidoEquipoPorId(IRepositorioPartidoEquipo repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<PartidoEquipoDTO> Handle(ConsultaObtenerPartidoEquipoPorId request)
        {
            var entity = await repositorio.ObtenerPorId(request.Id);
            if (entity is null)
                throw new ExcepcionDeValidacion("No se encontro la relacion partido-equipo");

            return entity.ADto();
        }
    }
}
