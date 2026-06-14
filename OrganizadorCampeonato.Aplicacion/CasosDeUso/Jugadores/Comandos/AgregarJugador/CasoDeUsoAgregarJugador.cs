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

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Jugadores.Comandos.AgregarJugador
{
    public class CasoDeUsoAgregarJugador : IRequestHandler<ComandoAgregarJugador, Guid>
    {
        private readonly IRepositorioPersona repositorioPersona;
        private readonly IRepositorioJugador repositorioJugador;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoAgregarJugador(IRepositorioPersona persona, IRepositorioJugador jugador,
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorioPersona = persona;
            this.repositorioJugador = jugador;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task<Guid> Handle(ComandoAgregarJugador request)
        {
            if (await repositorioPersona.IdentificacionYaRegistrada(request.Identificacion))
            {
                throw new ExcepcionDeValidacion("Identificación ya registrada");
            }

            Persona persona = new Persona(
                request.Identificacion, 
                request.Nombres, 
                request.Apellidos, 
                request.FechaNaciemiento, 
                request.Telefono!,
                request.Genero
            );
            Jugador jugado = new Jugador(persona.Id);

            try
            {
                await repositorioPersona.Agregar(persona);
                await repositorioJugador.Agregar(jugado);

                await unidadDeTrabajo.Persistir();
                return persona.Id;
            }
            catch (Exception)
            {
                await unidadDeTrabajo.Reversar();
                throw;
            }
        }
    }
}
