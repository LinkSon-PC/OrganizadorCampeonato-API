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

namespace OrganizadorCampeonato.Aplicacion.CasosDeUso.Entrenadores.Comandos.AgregarEntrenador
{
    public class CasoDeUsoAgregarEntrenador : IRequestHandler<ComandoAgregarEntrenador, Guid>
    {
        private readonly IRepositorioEntrenador repositorioEntrenador;
        private readonly IUnidadDeTrabajo unidadDeTrabajo;
        private readonly IRepositorioPersona repositorioPersona;

        public CasoDeUsoAgregarEntrenador(IRepositorioPersona repositorioPersona, IRepositorioEntrenador repositorioEntrenador,
            IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.repositorioEntrenador = repositorioEntrenador;
            this.unidadDeTrabajo = unidadDeTrabajo;
            this.repositorioPersona = repositorioPersona;
        }

        public async Task<Guid> Handle(ComandoAgregarEntrenador request)
        {
            if (await repositorioPersona.IdentificacionYaRegistrada(request.Identificacion))
            {
                throw new ExcepcionDeValidacion("Identificación ya registrada");
            }

            Persona persona = new Persona(
                request.Identificacion,
                request.Nombres,
                request.Apellidos,
                request.FechaNacimiento,
                request.Telefono!,
                request.Genero
            );
            Entrenador entrenador = new Entrenador(persona.Id);

            try
            {
                await repositorioPersona.Agregar(persona);
                await repositorioEntrenador.Agregar(entrenador);

                await unidadDeTrabajo.Persistir();
                return persona.Id;
            }
            catch (Exception)
            {
                await unidadDeTrabajo.Reversar();
                throw;
            }
        }
    }
}
