using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Personas.Comandos.EliminarPersona
{
    public class CasoDeUsoEliminarPersona : IRequestHandler<ComandoEliminarPersona>
    {
        private readonly IRepositorioPersona repositorio;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoEliminarPersona(IRepositorioPersona repositorio, IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorio = repositorio;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoEliminarPersona request)
        {
            var persona = await repositorio.ObtenerPorId(request.Id);
            if (persona is null)
                throw new ExcepcionDeValidacion("No se encontro la persona");

            try
            {
                await repositorio.Borrar(persona);
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
