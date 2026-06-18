using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Excepciones;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.EquipoJugadores.Comandos.EliminarJugadorEquipo
{
    public class CasoDeUsoEliminarJugadorEquipo : IRequestHandler<ComandoEliminarJugadorEquipo>
    {
        private readonly IRepositorioEquipoJugador repositorioEquipoJugador;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoEliminarJugadorEquipo(IRepositorioEquipoJugador repositorioEquipoJugador, IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorioEquipoJugador = repositorioEquipoJugador;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoEliminarJugadorEquipo request)
        {
            var equipoJugadorExistente = await repositorioEquipoJugador.ObtenerPorId(request.Id);
            if (equipoJugadorExistente is null)
                throw new ExcepcionDeValidacion("No se encontró la relación equipo-jugador");

            try
            {
                await repositorioEquipoJugador.Borrar(equipoJugadorExistente);
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
