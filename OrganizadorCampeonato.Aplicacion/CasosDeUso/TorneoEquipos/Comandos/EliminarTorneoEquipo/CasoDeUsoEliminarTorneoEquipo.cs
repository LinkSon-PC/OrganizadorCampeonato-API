using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.TorneoEquipos.Comandos.EliminarTorneoEquipo
{
    public class CasoDeUsoEliminarTorneoEquipo : IRequestHandler<ComandoEliminarTorneoEquipo>
    {
        private readonly IRepositorioTorneoEquipo repositorio;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoEliminarTorneoEquipo(IRepositorioTorneoEquipo repositorio, IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorio = repositorio;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoEliminarTorneoEquipo request)
        {
            var torneoEquipo = await repositorio.ObtenerPorId(request.Id);
            if (torneoEquipo is null)
                throw new ExcepcionDeValidacion("No se encontro la inscripcion del equipo");

            try
            {
                await repositorio.Borrar(torneoEquipo);
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
