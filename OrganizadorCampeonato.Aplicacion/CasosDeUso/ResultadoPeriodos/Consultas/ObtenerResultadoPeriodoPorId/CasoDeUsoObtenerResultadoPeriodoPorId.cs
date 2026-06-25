using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.ResultadoPeriodos.Consultas.ObtenerResultadoPeriodoPorId
{
    public class CasoDeUsoObtenerResultadoPeriodoPorId : IRequestHandler<ConsultaObtenerResultadoPeriodoPorId, ResultadoPeriodoDTO>
    {
        private readonly IRepositorioResultadoPeriodo repositorio;

        public CasoDeUsoObtenerResultadoPeriodoPorId(IRepositorioResultadoPeriodo repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<ResultadoPeriodoDTO> Handle(ConsultaObtenerResultadoPeriodoPorId request)
        {
            var entity = await repositorio.ObtenerPorId(request.Id);
            if (entity is null)
                throw new ExcepcionDeValidacion("No se encontro el resultado del periodo");

            return entity.ADto();
        }
    }
}
