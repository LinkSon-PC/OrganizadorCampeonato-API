using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Partidos.Comandos.EliminarPartido
{
    public class CasoDeUsoEliminarPartido : IRequestHandler<ComandoEliminarPartido>
    {
        private readonly IRepositorioPartido repositorio;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoEliminarPartido(IRepositorioPartido repositorio, IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorio = repositorio;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoEliminarPartido request)
        {
            var partido = await repositorio.ObtenerPorId(request.Id);
            if (partido is null)
                throw new ExcepcionDeValidacion("No se encontro el partido");

            try
            {
                await repositorio.Borrar(partido);
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
