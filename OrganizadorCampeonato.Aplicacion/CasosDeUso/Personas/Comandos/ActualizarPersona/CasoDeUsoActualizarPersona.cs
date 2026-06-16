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

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Personas.Comandos.ActualizarPersona
{
    public class CasoDeUsoActualizarPersona : IRequestHandler<ComandoActualizarPersona>
    {
        private readonly IRepositorioPersona repositorio;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoActualizarPersona(IRepositorioPersona repositorio, IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorio = repositorio;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task Handle(ComandoActualizarPersona request)
        {
            var personaExistente = await repositorio.ObtenerPorId(request.Id);
            if (personaExistente is null)
                throw new ExcepcionDeValidacion("No se encontró la persona");

            var personaActualizada = new Persona(
                request.Id,
                request.Identificacion,
                request.Nombres,
                request.Apellidos,
                request.FechaNaciemiento,
                request.Telefono ?? string.Empty,
                request.Genero
            );

            try
            {
                await repositorio.Actualizar(personaActualizada);
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
