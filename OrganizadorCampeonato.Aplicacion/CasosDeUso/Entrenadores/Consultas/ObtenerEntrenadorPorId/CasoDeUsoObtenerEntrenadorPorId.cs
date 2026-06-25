using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Entrenadores.Consultas.ObtenerEntrenadorPorId
{
    public class CasoDeUsoObtenerEntrenadorPorId : IRequestHandler<ConsultaObtenerEntrenadorPorId, EntrenadorDTO>
    {
        private readonly IRepositorioEntrenador repositorio;

        public CasoDeUsoObtenerEntrenadorPorId(IRepositorioEntrenador repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<EntrenadorDTO> Handle(ConsultaObtenerEntrenadorPorId request)
        {
            var entity = await repositorio.ObtenerPorId(request.Id);
            if (entity is null)
                throw new ExcepcionDeValidacion("No se encontro el entrenador");

            return entity.ADto();
        }
    }
}
