using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using OrganizadorCampeonato.Dominio.Enum;
using OrganizadorCampeonato.Dominio.Excepciones;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Partidos.Comandos.CancelarPartido
{
    public class CasoDeUsoCancelarPartido : IRequestHandler<ComandoCancelarPartido>
    {
        private readonly IRepositorioPartido repositorioPartido;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoCancelarPartido(IRepositorioPartido repositorioPartido, IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorioPartido = repositorioPartido;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoCancelarPartido request)
        {
            var partidoExistente = await repositorioPartido.ObtenerPorId(request.Id);
            if (partidoExistente is null)
                throw new ExcepcionDeValidacion("No se encontro el partido");

            if (partidoExistente.Estado == EstadoPartido.Completada)
                throw new ExcepcionReglaDeNegocio("No se puede cancelar un partido completado");

            if (partidoExistente.Estado == EstadoPartido.Cancelada)
                throw new ExcepcionReglaDeNegocio("El partido ya esta cancelado");

            var partidoCancelado = new Partido(
                request.Id,
                partidoExistente.FechaHora,
                partidoExistente.Lugar,
                partidoExistente.TorneoId,
                partidoExistente.Ronda,
                partidoExistente.Grupo ?? string.Empty
            )
            {
                Estado = EstadoPartido.Cancelada
            };

            try
            {
                await repositorioPartido.Actualizar(partidoCancelado);
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
