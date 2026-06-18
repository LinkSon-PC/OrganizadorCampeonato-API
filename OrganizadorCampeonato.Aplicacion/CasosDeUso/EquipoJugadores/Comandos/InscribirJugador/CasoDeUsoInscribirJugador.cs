using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using OrganizadorCampeonato.Dominio.Excepciones;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.EquipoJugadores.Comandos.InscribirJugador
{
    public class CasoDeUsoInscribirJugador : IRequestHandler<ComandoInscribirJugador>
    {
        private readonly IRepositorioEquipoJugador repositorioEquipoJugador;
        private readonly IRepositorioEquipo repositorioEquipo;
        private readonly IRepositorioJugador repositorioJugador;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoInscribirJugador(
            IRepositorioEquipoJugador repositorioEquipoJugador,
            IRepositorioEquipo repositorioEquipo,
            IRepositorioJugador repositorioJugador,
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorioEquipoJugador = repositorioEquipoJugador;
            this.repositorioEquipo = repositorioEquipo;
            this.repositorioJugador = repositorioJugador;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoInscribirJugador request)
        {
            var equipo = await repositorioEquipo.ObtenerPorId(request.EquipoId);
            if (equipo is null)
                throw new ExcepcionDeValidacion("No se encontró el equipo");

            var jugador = await repositorioJugador.ObtenerPorId(request.JugadorId);
            if (jugador is null)
                throw new ExcepcionDeValidacion("No se encontró el jugador");

            var existe = await repositorioEquipoJugador.ExisteInscripcion(request.EquipoId, request.JugadorId);
            if (existe)
                throw new ExcepcionReglaDeNegocio("El jugador ya está inscrito en este equipo");

            var equipoJugador = new EquipoJugador(
                Guid.CreateVersion7(),
                request.EquipoId,
                request.JugadorId
            );

            try
            {
                await repositorioEquipoJugador.Agregar(equipoJugador);
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
