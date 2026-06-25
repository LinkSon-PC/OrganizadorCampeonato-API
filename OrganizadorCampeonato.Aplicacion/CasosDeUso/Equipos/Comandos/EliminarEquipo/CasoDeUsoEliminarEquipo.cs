using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Equipos.Comandos.EliminarEquipo
{
    public class CasoDeUsoEliminarEquipo : IRequestHandler<ComandoEliminarEquipo>
    {
        private readonly IRepositorioEquipo repositorio;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoEliminarEquipo(IRepositorioEquipo repositorio, IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorio = repositorio;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoEliminarEquipo request)
        {
            var equipo = await repositorio.ObtenerPorId(request.Id);
            if (equipo is null)
                throw new ExcepcionDeValidacion("No se encontro el equipo");

            try
            {
                await repositorio.Borrar(equipo);
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
