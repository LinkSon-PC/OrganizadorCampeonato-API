using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Entrenadores.Comandos.ActualizarEntrenador
{
    public class CasoDeUsoActualizarEntrenador : IRequestHandler<ComandoActualizarEntrenador>
    {
        private readonly IRepositorioEntrenador repositorioEntrenador;
        private readonly IRepositorioPersona repositorioPersona;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoActualizarEntrenador(
            IRepositorioEntrenador repositorioEntrenador,
            IRepositorioPersona repositorioPersona,
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorioEntrenador = repositorioEntrenador;
            this.repositorioPersona = repositorioPersona;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoActualizarEntrenador request)
        {
            var entrenador = await repositorioEntrenador.ObtenerPorId(request.Id);
            if (entrenador is null)
                throw new ExcepcionDeValidacion("No se encontro el entrenador");

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
