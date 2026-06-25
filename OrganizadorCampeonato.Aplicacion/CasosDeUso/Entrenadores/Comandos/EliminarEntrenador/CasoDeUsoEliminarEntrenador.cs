using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Entrenadores.Comandos.EliminarEntrenador
{
    public class CasoDeUsoEliminarEntrenador : IRequestHandler<ComandoEliminarEntrenador>
    {
        private readonly IRepositorioEntrenador repositorioEntrenador;
        private readonly IRepositorioPersona repositorioPersona;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoEliminarEntrenador(
            IRepositorioEntrenador repositorioEntrenador,
            IRepositorioPersona repositorioPersona,
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorioEntrenador = repositorioEntrenador;
            this.repositorioPersona = repositorioPersona;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoEliminarEntrenador request)
        {
            var entrenador = await repositorioEntrenador.ObtenerPorId(request.Id);
            if (entrenador is null)
                throw new ExcepcionDeValidacion("No se encontro el entrenador");

            var persona = await repositorioPersona.ObtenerPorId(request.Id);
            if (persona is null)
                throw new ExcepcionDeValidacion("No se encontro la persona asociada");

            try
            {
                await repositorioEntrenador.Borrar(entrenador);
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
