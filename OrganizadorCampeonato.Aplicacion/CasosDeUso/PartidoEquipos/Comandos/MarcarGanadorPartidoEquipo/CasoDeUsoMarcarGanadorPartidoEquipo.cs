using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using OrganizadorCampeonato.Dominio.Enum;
using OrganizadorCampeonato.Dominio.Excepciones;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.PartidoEquipos.Comandos.MarcarGanadorPartidoEquipo
{
    public class CasoDeUsoMarcarGanadorPartidoEquipo : IRequestHandler<ComandoMarcarGanadorPartidoEquipo>
    {
        private readonly IRepositorioPartidoEquipo repositorioPartidoEquipo;
        private readonly IRepositorioPartido repositorioPartido;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoMarcarGanadorPartidoEquipo(
            IRepositorioPartidoEquipo repositorioPartidoEquipo,
            IRepositorioPartido repositorioPartido,
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorioPartidoEquipo = repositorioPartidoEquipo;
            this.repositorioPartido = repositorioPartido;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoMarcarGanadorPartidoEquipo request)
        {
            var partidoEquipoExistente = await repositorioPartidoEquipo.ObtenerPorId(request.Id);
            if (partidoEquipoExistente is null)
                throw new ExcepcionDeValidacion("No se encontró la relación partido-equipo");

            var partido = await repositorioPartido.ObtenerPorId(request.PartidoId);
            if (partido is null)
                throw new ExcepcionDeValidacion("No se encontró el partido");

            if (partido.Estado != EstadoPartido.Completada)
                throw new ExcepcionReglaDeNegocio("Solo se puede marcar ganador en partido completado");

            var partidoEquipoActualizado = new PartidoEquipo(
                request.Id,
                request.PartidoId,
                request.EquipoId,
                request.EsLocal
            )
            {
                EsGanador = request.EsGanador
            };

            try
            {
                await repositorioPartidoEquipo.Actualizar(partidoEquipoActualizado);
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
