using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using System;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.OficialesPartido.Comandos.EliminarOficialPartido
{
    public class CasoDeUsoEliminarOficialPartido : IRequestHandler<ComandoEliminarOficialPartido>
    {
        private readonly IRepositorioOficialPartido repositorio;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoEliminarOficialPartido(
            IRepositorioOficialPartido repositorio,
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorio = repositorio;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoEliminarOficialPartido request)
        {
            var oficialPartido = await repositorio.ObtenerPorId(request.Id);
            if (oficialPartido is null)
                throw new ExcepcionDeValidacion("No se encontro la relacion partido-oficial");

            try
            {
                await repositorio.Borrar(oficialPartido);
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
