using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoArbitros.Comandos.ActualizarPartidoArbitro
{
    public class CasoDeUsoActualizarPartidoArbitro : IRequestHandler<ComandoActualizarPartidoArbitro>
    {
        private readonly IRepositorioPartidoArbitro repositorio;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoActualizarPartidoArbitro(
            IRepositorioPartidoArbitro repositorio,
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorio = repositorio;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoActualizarPartidoArbitro request)
        {
            var partidoArbitroExistente = await repositorio.ObtenerPorId(request.Id);
            if (partidoArbitroExistente is null)
                throw new ExcepcionDeValidacion("No se encontro la relacion partido-arbitro");

            var partidoArbitroActualizado = new PartidoArbitro(
                request.Id,
                request.PartidoId,
                request.ArbitroId,
                request.Rol);

            try
            {
                await repositorio.Actualizar(partidoArbitroActualizado);
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
