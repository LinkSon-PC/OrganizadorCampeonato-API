using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using OrganizadorCampeonato.Dominio.Excepciones;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.EquipoJugadores.Comandos.ActivarEquipoJugador
{
    public class CasoDeUsoActivarEquipoJugador : IRequestHandler<ComandoActivarEquipoJugador>
    {
        private readonly IRepositorioEquipoJugador repositorioEquipoJugador;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoActivarEquipoJugador(IRepositorioEquipoJugador repositorioEquipoJugador, IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorioEquipoJugador = repositorioEquipoJugador;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoActivarEquipoJugador request)
        {
            var equipoJugadorExistente = await repositorioEquipoJugador.ObtenerPorId(request.Id);
            if (equipoJugadorExistente is null)
                throw new ExcepcionDeValidacion("No se encontró la relación equipo-jugador");

            if (equipoJugadorExistente.EstaActivo)
                throw new ExcepcionReglaDeNegocio("El jugador ya está activado");

            var equipoJugadorActualizado = new EquipoJugador(
                request.Id,
                request.EquipoId,
                request.JugadorId
            )
            {
                EstaActivo = true,
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
