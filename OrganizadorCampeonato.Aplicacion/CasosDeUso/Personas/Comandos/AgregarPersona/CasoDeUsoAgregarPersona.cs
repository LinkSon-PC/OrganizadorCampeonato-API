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

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Personas.Comandos.AgregarPersona
{
    public class CasoDeUsoAgregarPersona : IRequestHandler<ComandoAgregarPersona, Guid>
    {
        private readonly IRepositorioPersona repositorio;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;

        public CasoDeUsoAgregarPersona(IRepositorioPersona repositorio, IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorio = repositorio;
            this.unidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task<Guid> Handle(ComandoAgregarPersona request)
        {
            if (await repositorio.IdentificacionYaRegistrada(request.Identificacion))
            {
                throw new ExcepcionDeValidacion("Identificación ya registrada");
            }

            var persona = new Persona(
                request.Identificacion,
                request.Nombres, 
                request.Apellidos, 
                request.FechaNaciemiento, 
                request.Telefono!,
                request.Genero
            );

            try
            {
                var resultado = await repositorio.Agregar(persona);
                await unidadDeTrabajo.Persistir();
                return resultado.Id;
            }
            catch (Exception)
            {
                await unidadDeTrabajo.Reversar();
                throw;
            }
        }
    }
}
