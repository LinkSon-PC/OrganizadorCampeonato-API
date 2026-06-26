using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using OrganizadorCampeonato.Dominio.Excepciones;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.TorneoEquipos.Comandos.InscribirEquipo
{
    public class CasoDeUsoInscribirEquipo : IRequestHandler<ComandoInscribirEquipo>
    {
        private readonly IRepositorioTorneoEquipo repositorioTorneoEquipo;
        private readonly IRepositorioTorneo repositorioTorneo;
        private readonly IRepositorioEquipo repositorioEquipo;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoInscribirEquipo(
            IRepositorioTorneoEquipo repositorioTorneoEquipo,
            IRepositorioTorneo repositorioTorneo,
            IRepositorioEquipo repositorioEquipo,
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorioTorneoEquipo = repositorioTorneoEquipo;
            this.repositorioTorneo = repositorioTorneo;
            this.repositorioEquipo = repositorioEquipo;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoInscribirEquipo request)
        {
            var torneo = await repositorioTorneo.ObtenerPorId(request.TorneoId);
            if (torneo is null)
                throw new ExcepcionDeValidacion("No se encontró el torneo");

            var equipo = await repositorioEquipo.ObtenerPorId(request.EquipoId);
            if (equipo is null)
                throw new ExcepcionDeValidacion("No se encontró el equipo");

            var existe = await repositorioTorneoEquipo.ExisteInscripcion(request.TorneoId, request.EquipoId);
            if (existe)
                throw new ExcepcionReglaDeNegocio("El equipo ya está inscrito en este torneo");

            var torneoEquipo = new TorneoEquipo(
                request.Id,
                request.TorneoId,
                request.EquipoId,
                request.Posicion,
                request.Grupo,
                request.PosicionGrupo
            );

            try
            {
                await repositorioTorneoEquipo.Agregar(torneoEquipo);
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
