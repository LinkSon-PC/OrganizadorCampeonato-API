using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Jugadores.Consultas.ObtenerJugadorPorId
{
    public class CasoDeUsoObtenerJugadorPorId : IRequestHandler<ConsultaObtenerJugadorPorId, JugadorPorIdDTO>
    {
        private readonly IRepositorioJugador repositorio;

        public CasoDeUsoObtenerJugadorPorId(IRepositorioJugador repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<JugadorPorIdDTO> Handle(ConsultaObtenerJugadorPorId request)
        {
            var entity = await repositorio.ObtenerPorId(request.Id);
            if (entity is null)
                throw new ExcepcionDeValidacion("No se encontro el jugador");

            return entity.ADto();
        }
    }
}
