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

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Entrenadores.Comandos.AsignarEntrenador
{
    public class CasoDeUsoAsignarEntrenador : IRequestHandler<ComandoAsignarEntrenador>
    {
        private readonly IRepositorioEntrenador repositorioEntrenador;
        private readonly IRepositorioPersona repositorioPersona;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoAsignarEntrenador(IRepositorioEntrenador repositorioEntrenador, IRepositorioPersona repositorioPersona, 
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorioEntrenador = repositorioEntrenador;
            this.repositorioPersona = repositorioPersona;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoAsignarEntrenador request)
        {
            var persona = await repositorioPersona.ObtenerPorIdentificacion(request.Identificacion);
            if (persona is null)
                throw new ExcepcionDeValidacion("No se encontro persona");

            var buscarJugador = await repositorioPersona.PersonaComoJugador(request.Identificacion);
            if (buscarJugador)
                throw new ExcepcionDeValidacion("Persona ya asignada como jugador");

            var entrenador = new Entrenador(persona.Id);

            try
            {
                await repositorioEntrenador.Agregar(entrenador);
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
