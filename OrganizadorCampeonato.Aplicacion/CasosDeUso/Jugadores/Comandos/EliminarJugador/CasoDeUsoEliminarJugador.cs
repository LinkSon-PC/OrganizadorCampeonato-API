using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Jugadores.Comandos.EliminarJugador
{
    public class CasoDeUsoEliminarJugador : IRequestHandler<ComandoEliminarJugador>
    {
        private readonly IRepositorioJugador repositorioJugador;
        private readonly IRepositorioPersona repositorioPersona;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoEliminarJugador(
            IRepositorioJugador repositorioJugador,
            IRepositorioPersona repositorioPersona,
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorioJugador = repositorioJugador;
            this.repositorioPersona = repositorioPersona;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoEliminarJugador request)
        {
            var jugador = await repositorioJugador.ObtenerPorId(request.Id);
            if (jugador is null)
                throw new ExcepcionDeValidacion("No se encontro el jugador");

            var persona = await repositorioPersona.ObtenerPorId(request.Id);
            if (persona is null)
                throw new ExcepcionDeValidacion("No se encontro la persona asociada");

            try
            {
                await repositorioJugador.Borrar(jugador);
                await repositorioPersona.Borrar(persona);
                await unidadDeTrabajo.Persistir();
            }
            catch (Exception)
            {
                await unidadDeTrabajo.Reversar();
                throw;
            }
        }
    }
}
