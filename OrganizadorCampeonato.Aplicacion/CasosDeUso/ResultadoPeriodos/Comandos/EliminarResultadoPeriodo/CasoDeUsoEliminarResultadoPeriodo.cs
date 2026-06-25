using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.ResultadoPeriodos.Comandos.EliminarResultadoPeriodo
{
    public class CasoDeUsoEliminarResultadoPeriodo : IRequestHandler<ComandoEliminarResultadoPeriodo>
    {
        private readonly IRepositorioResultadoPeriodo repositorio;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoEliminarResultadoPeriodo(
            IRepositorioResultadoPeriodo repositorio,
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorio = repositorio;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoEliminarResultadoPeriodo request)
        {
            var resultadoPeriodo = await repositorio.ObtenerPorId(request.Id);
            if (resultadoPeriodo is null)
                throw new ExcepcionDeValidacion("No se encontro el resultado del periodo");

            try
            {
                await repositorio.Borrar(resultadoPeriodo);
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
