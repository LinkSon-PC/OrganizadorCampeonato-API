using OrganizadorCampeonato.Aplicacion.Comunes.Mediator;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
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
            var persona = await repositorio.ObtenerPorId(request.Id);
            if (persona is null)
                throw new ExcepcionDeValidacion("No se encontró la persona");

            persona.SetNombres(request.Nombres);
            persona.SetApellidos(request.Apellidos);
            persona.SetIdentificacion(request.Identificacion);
            persona.SetFechaNacimiento(request.FechaNaciemiento);
            persona.SetTelefono(request.Telefono);

            try
            {
                await repositorio.Actualizar(persona);
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
