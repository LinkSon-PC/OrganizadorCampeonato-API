using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Enum;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Partidos.Consultas.ObtenerPartidoPorId
{
    public class CasoDeUsoObtenerPartidoPorId : IRequestHandler<ConsultaObtenerPartidoPorId, PartidoDTO>
    {
        private readonly IRepositorioPartido repositorio;

        public CasoDeUsoObtenerPartidoPorId(IRepositorioPartido repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<PartidoDTO> Handle(ConsultaObtenerPartidoPorId request)
        {
            var entity = await repositorio.ObtenerPorId(request.Id);
            if (entity is null)
                throw new ExcepcionDeValidacion("No se encontro el partido");

            return entity.ADto();
        }
    }
}
