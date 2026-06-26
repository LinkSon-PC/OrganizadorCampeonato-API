using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Partidos.Comandos.AgregarPartido
{
    public class CasoDeUsoAgregarPartido : IRequestHandler<ComandoAgregarPartido, Guid>
    {
        private readonly IRepositorioPartido repositorio;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoAgregarPartido(IRepositorioPartido repositorio, IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorio = repositorio;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task<Guid> Handle(ComandoAgregarPartido request)
        {
            var partido = new Partido(
                Guid.CreateVersion7(),
                request.FechaHora,
                request.Lugar,
                request.TorneoId,
                request.Fase,
                request.Jornada,
                request.Grupo ?? string.Empty,
                request.NumeroRondaKO,
                request.PartidoOrigenLocalId,
                request.PartidoOrigenVisitanteId
            );

            try
            {
                var respuesta = await repositorio.Agregar(partido);
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
