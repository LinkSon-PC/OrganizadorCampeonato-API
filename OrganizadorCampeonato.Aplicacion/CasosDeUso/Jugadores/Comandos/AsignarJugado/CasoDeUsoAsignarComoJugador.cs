using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Jugadores.Comandos.AsignarJugado
{
    public class CasoDeUsoAsignarComoJugador : IRequestHandler<ComandoAsiganarJugador>
    {
        private readonly IRepositorioPersona repositorioPersona;
        private readonly IRepositorioJugador repositorioJugador;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoAsignarComoJugador(IRepositorioPersona repositorioPersona, IRepositorioJugador repositorioJugador,
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorioPersona = repositorioPersona;
            this.repositorioJugador = repositorioJugador;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoAsiganarJugador request)
        {
            var persona = await repositorioPersona.ObtenerPorIdentificacion(request.Identificacion);
            if (persona is null)
                throw new ExcepcionDeValidacion("No se encontro persona");

            var buscarJugador = await repositorioPersona.PersonaComoJugador(request.Identificacion);
            if (buscarJugador)
                throw new ExcepcionDeValidacion("Persona ya asignada como jugador");

            var jugador = new Jugador(persona.Id);

            try
            {
                await repositorioJugador.Agregar(jugador);
                await unidadDeTrabajo.Persistir();
            }
            catch (Exception ex)
            {
                await unidadDeTrabajo.Reversar();
                throw;
            }
        }
    }
}
