using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Jugadores.Consultas.ObtenerTodosJugadores
{
    public class CasoDeUsoObtenerTodosJugadores : IRequestHandler<ConsultaObtenerTodosJugadores, List<JugadorDTO>>
    {
        private readonly IRepositorioJugador repositorio;

        public CasoDeUsoObtenerTodosJugadores(IRepositorioJugador repositorio)
        {
            this.repositorio = repositorio;
        }

        public Task<List<JugadorDTO>> Handle(ConsultaObtenerTodosJugadores request)
        {
            var jugadores = repositorio.ObtenerTodosJugadores().Result
                .Select(x => x.ADto()).ToList();

            return Task.FromResult(jugadores);
        }
    }
}
