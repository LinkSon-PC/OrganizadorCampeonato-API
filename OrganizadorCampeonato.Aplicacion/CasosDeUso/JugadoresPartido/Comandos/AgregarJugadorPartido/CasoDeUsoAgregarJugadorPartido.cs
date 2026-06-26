using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.JugadoresPartido.Comandos.AgregarJugadorPartido
{
    public class CasoDeUsoAgregarJugadorPartido : IRequestHandler<ComandoAgregarJugadorPartido, Guid>
    {
        private readonly IRepositorioJugadorPartido repositorio;
        private readonly IRepositorioPartidoEquipo repositorioPartidoEquipo;
        private readonly IRepositorioJugador repositorioJugador;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoAgregarJugadorPartido(
            IRepositorioJugadorPartido repositorio,
            IRepositorioPartidoEquipo repositorioPartidoEquipo,
            IRepositorioJugador repositorioJugador,
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorio = repositorio;
            this.repositorioPartidoEquipo = repositorioPartidoEquipo;
            this.repositorioJugador = repositorioJugador;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task<Guid> Handle(ComandoAgregarJugadorPartido request)
        {
            var partidoEquipo = await repositorioPartidoEquipo.ObtenerPorId(request.PartidoEquipoId);
            if (partidoEquipo is null)
                throw new ExcepcionDeValidacion("No se encontro el partido-equipo");

            var jugador = await repositorioJugador.ObtenerPorId(request.JugadorId);
            if (jugador is null)
                throw new ExcepcionDeValidacion("No se encontro el jugador");

            var jugadorPartido = new JugadorPartido(
                Guid.CreateVersion7(),
                request.PartidoEquipoId,
                request.JugadorId,
                request.Dorsal,
                request.EsCapitan,
                request.EsTitular);

            try
            {
                var respuesta = await repositorio.Agregar(jugadorPartido);
                await unidadDeTrabajo.Persistir();
                return respuesta.Id;
            }
            catch (Exception)
            {
                await unidadDeTrabajo.Reversar();
                throw;
            }
        }
    }
}
