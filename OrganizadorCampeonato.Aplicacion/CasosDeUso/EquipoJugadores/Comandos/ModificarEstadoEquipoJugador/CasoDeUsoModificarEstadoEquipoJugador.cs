using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using OrganizadorCampeonato.Dominio.Excepciones;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.EquipoJugadores.Comandos.ModificarEstadoEquipoJugador
{
    public class CasoDeUsoModificarEstadoEquipoJugador : IRequestHandler<ComandoModificarEstadoEquipoJugador>
    {
        private readonly IRepositorioEquipoJugador repositorioEquipoJugador;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoModificarEstadoEquipoJugador(IRepositorioEquipoJugador repositorioEquipoJugador, IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorioEquipoJugador = repositorioEquipoJugador;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoModificarEstadoEquipoJugador request)
        {
            var equipoJugadorExistente = await repositorioEquipoJugador.ObtenerPorEquipoYJugador(request.EquipoId, request.JugadorId);
            if (equipoJugadorExistente is null)
                throw new ExcepcionDeValidacion("No se encontró la relación equipo-jugador");

            if (equipoJugadorExistente.EstaActivo == request.EstaActivo)
                throw new ExcepcionReglaDeNegocio($"El jugador ya está {(request.EstaActivo ? "activado" : "desactivado")}");

            var equipoJugadorActualizado = new EquipoJugador(
                equipoJugadorExistente.Id,
                request.EquipoId,
                request.JugadorId
            )
            {
                EstaActivo = request.EstaActivo,
                FechaIncorporacion = equipoJugadorExistente.FechaIncorporacion
            };

            try
            {
                await repositorioEquipoJugador.Actualizar(equipoJugadorActualizado);
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
