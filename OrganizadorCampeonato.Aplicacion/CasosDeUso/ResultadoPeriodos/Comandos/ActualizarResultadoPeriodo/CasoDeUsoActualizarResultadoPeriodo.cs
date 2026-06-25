using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.ResultadoPeriodos.Comandos.ActualizarResultadoPeriodo
{
    public class CasoDeUsoActualizarResultadoPeriodo : IRequestHandler<ComandoActualizarResultadoPeriodo>
    {
        private readonly IRepositorioResultadoPeriodo repositorio;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoActualizarResultadoPeriodo(
            IRepositorioResultadoPeriodo repositorio,
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorio = repositorio;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoActualizarResultadoPeriodo request)
        {
            var resultadoPeriodoExistente = await repositorio.ObtenerPorId(request.Id);
            if (resultadoPeriodoExistente is null)
                throw new ExcepcionDeValidacion("No se encontro el resultado del periodo");

            var resultadoPeriodoActualizado = new ResultadoPeriodo(
                request.Id,
                request.PartidoId,
                request.Periodo,
                request.NumeroProrroga,
                request.PuntosLocal,
                request.PuntosVisitante);

            try
            {
                await repositorio.Actualizar(resultadoPeriodoActualizado);
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
