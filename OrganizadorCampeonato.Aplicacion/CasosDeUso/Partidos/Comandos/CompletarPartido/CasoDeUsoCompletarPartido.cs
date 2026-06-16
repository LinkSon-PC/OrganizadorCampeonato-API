using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using OrganizadorCampeonato.Dominio.Enum;
using OrganizadorCampeonato.Dominio.Excepciones;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Partidos.Comandos.CompletarPartido
{
    public class CasoDeUsoCompletarPartido : IRequestHandler<ComandoCompletarPartido>
    {
        private readonly IRepositorioPartido repositorioPartido;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoCompletarPartido(IRepositorioPartido repositorioPartido, IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorioPartido = repositorioPartido;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoCompletarPartido request)
        {
            var partidoExistente = await repositorioPartido.ObtenerPorId(request.Id);
            if (partidoExistente is null)
                throw new ExcepcionDeValidacion("No se encontró el partido");

            if (partidoExistente.Estado == EstadoPartido.Cancelada)
                throw new ExcepcionReglaDeNegocio("No se puede completar un partido cancelado");

            if (partidoExistente.Estado == EstadoPartido.Completada)
                throw new ExcepcionReglaDeNegocio("El partido ya está completado");

            var partidoCompletado = new Partido(
                request.Id,
                request.FechaHora,
                request.Lugar,
                request.TorneoId,
                request.Ronda,
                request.Grupo ?? string.Empty
            )
            {
                Estado = EstadoPartido.Completada,
                GanadorId = request.GanadorId,
                PuntosLocal_P1 = request.PuntosLocal_P1,
                PuntosVisitante_P1 = request.PuntosVisitante_P1,
                PuntosLocal_P2 = request.PuntosLocal_P2,
                PuntosVisitante_P2 = request.PuntosVisitante_P2,
                PuntosLocal_P3 = request.PuntosLocal_P3,
                PuntosVisitante_P3 = request.PuntosVisitante_P3,
                PuntosLocal_P4 = request.PuntosLocal_P4,
                PuntosVisitante_P4 = request.PuntosVisitante_P4,
                PuntosLocal_Prorroga = request.PuntosLocal_Prorroga,
                PuntosVisitante_Prorroga = request.PuntosVisitante_Prorroga,
                PuntosLocal_Prorroga2 = request.PuntosLocal_Prorroga2,
                PuntosVisitante_Prorroga2 = request.PuntosVisitante_Prorroga2
            };

            try
            {
                await repositorioPartido.Actualizar(partidoCompletado);
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
