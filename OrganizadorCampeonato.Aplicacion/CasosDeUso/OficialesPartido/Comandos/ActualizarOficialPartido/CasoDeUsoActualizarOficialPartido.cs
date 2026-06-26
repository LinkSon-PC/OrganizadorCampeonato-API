using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.OficialesPartido.Comandos.ActualizarOficialPartido
{
    public class CasoDeUsoActualizarOficialPartido : IRequestHandler<ComandoActualizarOficialPartido>
    {
        private readonly IRepositorioOficialPartido repositorio;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoActualizarOficialPartido(
            IRepositorioOficialPartido repositorio,
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorio = repositorio;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoActualizarOficialPartido request)
        {
            var oficialPartidoExistente = await repositorio.ObtenerPorId(request.Id);
            if (oficialPartidoExistente is null)
                throw new ExcepcionDeValidacion("No se encontro la relacion partido-oficial");

            var oficialPartidoActualizado = new OficialPartido(
                request.Id,
                request.PartidoId,
                request.ArbitroId,
                request.Rol);

            try
            {
                await repositorio.Actualizar(oficialPartidoActualizado);
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
