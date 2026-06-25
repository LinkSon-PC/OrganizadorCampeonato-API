using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Torneos.Comandos.EliminarTorneo
{
    public class CasoDeUsoEliminarTorneo : IRequestHandler<ComandoEliminarTorneo>
    {
        private readonly IRepositorioTorneo repositorio;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoEliminarTorneo(IRepositorioTorneo repositorio, IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorio = repositorio;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoEliminarTorneo request)
        {
            var torneo = await repositorio.ObtenerPorId(request.Id);
            if (torneo is null)
                throw new ExcepcionDeValidacion("No se encontro el torneo");

            try
            {
                await repositorio.Borrar(torneo);
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
