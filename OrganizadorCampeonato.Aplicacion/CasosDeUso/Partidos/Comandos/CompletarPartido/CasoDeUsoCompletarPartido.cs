using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using OrganizadorCampeonato.Dominio.Enum;
using OrganizadorCampeonato.Dominio.Excepciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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
            var partidos = await repositorioPartido.ObtenerTodos();
            var partidoExistente = await partidos
                .Include(p => p.ResultadosPeriodos)
                .FirstOrDefaultAsync(p => p.Id == request.Id);

            if (partidoExistente is null)
                throw new ExcepcionDeValidacion("No se encontro el partido");

            if (partidoExistente.Estado == EstadoPartido.Cancelada)
                throw new ExcepcionReglaDeNegocio("No se puede completar un partido cancelado");

            if (partidoExistente.Estado == EstadoPartido.Completada)
                throw new ExcepcionReglaDeNegocio("El partido ya esta completado");

            if (!partidoExistente.ResultadosPeriodos.Any())
                throw new ExcepcionReglaDeNegocio("El partido no tiene resultados de periodos registrados");

            var partidoCompletado = new Partido(
                request.Id,
                partidoExistente.FechaHora,
                partidoExistente.Lugar,
                partidoExistente.TorneoId,
                partidoExistente.Ronda,
                partidoExistente.Grupo ?? string.Empty
            )
            {
                Estado = EstadoPartido.Completada
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
