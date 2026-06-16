using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Equipos.Comandos.ActualizarEquipo
{
    public class CasoDeUsoActualizarEquipo : IRequestHandler<ComandoActualizarEquipo>
    {
        private readonly IRepositorioEquipo repositorioEquipo;
        private readonly IRepositorioEntrenador repositorioEntrenador;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoActualizarEquipo(IRepositorioEquipo repositorioEquipo, IRepositorioEntrenador repositorioEntrenador, 
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorioEquipo = repositorioEquipo;
            this.repositorioEntrenador = repositorioEntrenador;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoActualizarEquipo request)
        {
            var equipoExistente = await repositorioEquipo.ObtenerPorId(request.Id);
            if (equipoExistente is null)
                throw new ExcepcionDeValidacion("No se encotró equipo");

            if (request.EntrenadorId != null)
            {
                var entrenador = repositorioEntrenador.ObtenerPorId(request.EntrenadorId ?? Guid.Empty);
                if (entrenador is null)
                    throw new ExcepcionDeValidacion("No se encotró entrenador");

            }

            var equipoActualizado = new Equipo(
                request.Id,
                request.Nombre,
                request.EntrenadorId,
                request.CategoriaId
            );

            try
            {
                await repositorioEquipo.Actualizar(equipoActualizado);
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
