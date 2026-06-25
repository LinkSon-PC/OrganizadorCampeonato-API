using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Partidos.Consultas.ObtenerTodosPartidos
{
    public class CasoDeUsoObtenerTodosPartidos : IRequestHandler<ConsultaObtenerTodosPartidos, List<ListadoPartidoDTO>>
    {
        private readonly IRepositorioPartido repositorio;

        public CasoDeUsoObtenerTodosPartidos(IRepositorioPartido repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<List<ListadoPartidoDTO>> Handle(ConsultaObtenerTodosPartidos request)
        {
            var entities = await repositorio.ObtenerTodos();
            var partidosConPeriodos = await entities
                .Include(p => p.ResultadosPeriodos)
                .ToListAsync();
            return partidosConPeriodos.Select(x => x.ADto()).ToList();
        }
    }
}
