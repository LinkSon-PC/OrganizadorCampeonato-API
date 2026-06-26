using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.JugadoresPartido.Comandos.ActualizarJugadorPartido
{
    public class CasoDeUsoActualizarJugadorPartido : IRequestHandler<ComandoActualizarJugadorPartido>
    {
        private readonly IRepositorioJugadorPartido repositorio;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoActualizarJugadorPartido(
            IRepositorioJugadorPartido repositorio,
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorio = repositorio;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoActualizarJugadorPartido request)
        {
            var jugadorPartidoExistente = await repositorio.ObtenerPorId(request.Id);
            if (jugadorPartidoExistente is null)
                throw new ExcepcionDeValidacion("No se encontro la relacion jugador-partido");

            var jugadorPartidoActualizado = new JugadorPartido(
                request.Id,
                jugadorPartidoExistente.PartidoEquipoId,
                jugadorPartidoExistente.JugadorId,
                request.Dorsal,
                request.EsCapitan,
                request.EsTitular)
            {
                Jugo = request.Jugo
            };

            try
            {
                await repositorio.Actualizar(jugadorPartidoActualizado);
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
