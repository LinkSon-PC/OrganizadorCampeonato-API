using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Jugadores.Comandos.ActualizarJugador
{
    public class CasoDeUsoActualizarJugador : IRequestHandler<ComandoActualizarJugador>
    {
        private readonly IRepositorioJugador repositorioJugador;
        private readonly IRepositorioPersona repositorioPersona;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoActualizarJugador(
            IRepositorioJugador repositorioJugador,
            IRepositorioPersona repositorioPersona,
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorioJugador = repositorioJugador;
            this.repositorioPersona = repositorioPersona;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoActualizarJugador request)
        {
            var jugador = await repositorioJugador.ObtenerPorId(request.Id);
            if (jugador is null)
                throw new ExcepcionDeValidacion("No se encontro el jugador");

            var persona = await repositorioPersona.ObtenerPorId(request.Id);
            if (persona is null)
                throw new ExcepcionDeValidacion("No se encontro la persona asociada");

            var personaActualizada = new Persona(
                request.Id,
                request.Identificacion,
                request.Nombres,
                request.Apellidos,
                request.FechaNacimiento,
                request.Telefono!,
                request.Genero
            );

            try
            {
                await repositorioPersona.Actualizar(personaActualizada);
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
