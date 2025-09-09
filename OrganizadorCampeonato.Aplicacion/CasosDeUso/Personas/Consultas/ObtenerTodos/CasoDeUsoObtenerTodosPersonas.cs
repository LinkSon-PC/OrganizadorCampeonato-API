using OrganizadorCampeonato.Aplicacion.Comunes.Dtos;
using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Personas.Consultas.ObtenerTodos
{
    public class CasoDeUsoObtenerTodosPersonas : IRequestHandler<ConsultaObtenerTodosPersonas, PaginadoDTO<ListadoPersonasDTO>>
    {
        private readonly IRepositorioPersona repositorio;

        public CasoDeUsoObtenerTodosPersonas(IRepositorioPersona repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<PaginadoDTO<ListadoPersonasDTO>> Handle(ConsultaObtenerTodosPersonas request)
        {
            var total = await repositorio.ObtenerTotalRegistros();
            var personasDto = await repositorio.ObtenerPaginado(request);
            var respuesta = personasDto.Select(p => p.ADto()).ToList();

            return new PaginadoDTO<ListadoPersonasDTO>
            {
                Total = total,
                Elementos = respuesta
            };
        }
    }
}
