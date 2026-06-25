using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using Microsoft.EntityFrameworkCore;
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
            var partidos = await repositorio.ObtenerTodos();
            var entity = await partidos
                .Include(p => p.ResultadosPeriodos)
                .FirstOrDefaultAsync(p => p.Id == request.Id);

            if (entity is null)
                throw new ExcepcionDeValidacion("No se encontro el partido");

            return entity.ADto();
        }
    }
}
