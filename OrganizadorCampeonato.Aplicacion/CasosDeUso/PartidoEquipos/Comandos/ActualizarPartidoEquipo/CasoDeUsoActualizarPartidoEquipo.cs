using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoEquipos.Comandos.ActualizarPartidoEquipo
{
    public class CasoDeUsoActualizarPartidoEquipo : IRequestHandler<ComandoActualizarPartidoEquipo>
    {
        private readonly IRepositorioPartidoEquipo repositorio;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoActualizarPartidoEquipo(
            IRepositorioPartidoEquipo repositorio,
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorio = repositorio;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoActualizarPartidoEquipo request)
        {
            var partidoEquipoExistente = await repositorio.ObtenerPorId(request.Id);
            if (partidoEquipoExistente is null)
                throw new ExcepcionDeValidacion("No se encontro la relacion partido-equipo");

            var partidoEquipoActualizado = new PartidoEquipo(
                request.Id,
                request.PartidoId,
                request.EquipoId,
                request.EsLocal)
            {
                EsGanador = request.EsGanador
            };

            try
            {
                await repositorio.Actualizar(partidoEquipoActualizado);
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
