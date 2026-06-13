using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
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

        public Task Handle(ComandoAgregarTorneo request)
        {
            throw new NotImplementedException();
        }
    }
}
