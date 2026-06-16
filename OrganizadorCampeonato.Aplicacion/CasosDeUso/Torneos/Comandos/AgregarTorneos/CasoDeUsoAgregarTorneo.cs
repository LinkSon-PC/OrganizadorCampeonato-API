using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Torneos.Comandos.AgregarTorneos
{
    public class CasoDeUsoAgregarTorneo : IRequestHandler<ComandoAgregarTorneo>
    {
        private readonly IRepositorioTorneo repositorio;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoAgregarTorneo( IRepositorioTorneo repositorio,
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorio = repositorio;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoAgregarTorneo request)
        {
            var torneo = new Torneo(
                Guid.CreateVersion7(),
                request.Nombre,
                request.Lugar,
                request.CategoriaId,
                request.Formato,
                request.FechaInicio,
                request.FechaFin,
                request.Descripcion ?? string.Empty
            );

            try
            {
                await repositorio.Agregar(torneo);
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
