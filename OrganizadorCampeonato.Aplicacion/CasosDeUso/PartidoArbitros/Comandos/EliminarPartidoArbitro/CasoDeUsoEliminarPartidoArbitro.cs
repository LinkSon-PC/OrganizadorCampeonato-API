using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoArbitros.Comandos.EliminarPartidoArbitro
{
    public class CasoDeUsoEliminarPartidoArbitro : IRequestHandler<ComandoEliminarPartidoArbitro>
    {
        private readonly IRepositorioPartidoArbitro repositorio;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoEliminarPartidoArbitro(
            IRepositorioPartidoArbitro repositorio,
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorio = repositorio;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoEliminarPartidoArbitro request)
        {
            var partidoArbitro = await repositorio.ObtenerPorId(request.Id);
            if (partidoArbitro is null)
                throw new ExcepcionDeValidacion("No se encontro la relacion partido-arbitro");

            try
            {
                await repositorio.Borrar(partidoArbitro);
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
