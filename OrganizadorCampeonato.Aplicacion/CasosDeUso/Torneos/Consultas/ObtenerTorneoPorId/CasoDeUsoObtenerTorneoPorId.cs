using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Torneos.Consultas.ObtenerTorneoPorId
{
    public class CasoDeUsoObtenerTorneoPorId : IRequestHandler<ConsultaObtenerTorneoPorId, TorneoPorIdDTO>
    {
        private readonly IRepositorioTorneo repositorio;

        public CasoDeUsoObtenerTorneoPorId(IRepositorioTorneo repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<TorneoPorIdDTO> Handle(ConsultaObtenerTorneoPorId request)
        {
            var entity = await repositorio.ObtenerPorId(request.Id);
            if (entity is null)
                throw new ExcepcionDeValidacion("No se encontro el torneo");

            return entity.ADto();
        }
    }
}
