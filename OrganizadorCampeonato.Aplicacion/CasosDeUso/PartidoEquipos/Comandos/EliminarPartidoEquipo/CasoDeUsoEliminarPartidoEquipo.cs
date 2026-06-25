using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoEquipos.Comandos.EliminarPartidoEquipo
{
    public class CasoDeUsoEliminarPartidoEquipo : IRequestHandler<ComandoEliminarPartidoEquipo>
    {
        private readonly IRepositorioPartidoEquipo repositorio;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoEliminarPartidoEquipo(
            IRepositorioPartidoEquipo repositorio,
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorio = repositorio;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoEliminarPartidoEquipo request)
        {
            var partidoEquipo = await repositorio.ObtenerPorId(request.Id);
            if (partidoEquipo is null)
                throw new ExcepcionDeValidacion("No se encontro la relacion partido-equipo");

            try
            {
                await repositorio.Borrar(partidoEquipo);
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
