using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Torneos.Comandos.ActualizarTorneos
{
    public class CasoDeUsoActualizarTorneo : IRequestHandler<ComandoActualizarTorneo>
    {
        private readonly IRepositorioTorneo repositorio;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoActualizarTorneo(IRepositorioTorneo repositorio, IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorio = repositorio;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoActualizarTorneo request)
        {
            var torneoExistente = await repositorio.ObtenerPorId(request.Id);
            if (torneoExistente is null)
                throw new ExcepcionDeValidacion("No se encontro el torneo");

            var torneoActualizado = new Torneo(
                request.Id,
                request.Nombre,
                request.Lugar,
                request.CategoriaId ?? torneoExistente.CategoriaId,
                request.Formato,
                request.FechaInicio,
                request.FechaFin,
                request.Descripcion ?? string.Empty
            );

            try
            {
                await repositorio.Actualizar(torneoActualizado);
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
