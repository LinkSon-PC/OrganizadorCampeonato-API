using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.Exceptions;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Personas.Comandos.AgregarPersona;
using OrganizadorCampeonato.Aplicacion.Contratos.Persistencia;
using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Aplicacion.Excepciones;
using OrganizadorCampeonato.Dominio.Entidades;
using OrganizadorCampeonato.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Tests.Aplicacion.CasoDeUso.Personas
{
    [TestClass]
    public class AgregarPersonaTests
    {
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
        private IRepositorioPersona repositorio;
        private IUnidadDeTrabajo unidadDeTrabajo;
        private CasoDeUsoAgregarPersona casoDeUso;
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.

        [TestInitialize]
        public void Initial()
        {
            repositorio = Substitute.For<IRepositorioPersona>();
            unidadDeTrabajo = Substitute.For<IUnidadDeTrabajo>();
            casoDeUso = new CasoDeUsoAgregarPersona(repositorio, unidadDeTrabajo);
        }

        [TestMethod]
        public async Task Handle_Exitoso()
        {
            var comando = new ComandoAgregarPersona
            {
                Identificacion = "1112223334445", 
                Nombres = "Nombre A", 
                Apellidos = "Apellido 2", 
                FechaNaciemiento = DateTime.UtcNow, 
                Telefono = "22223333",
                Genero = TipoGenero.Masculino
            };

            var persona = new Persona(Guid.CreateVersion7(), "1112223334445", "Nombre A", "Apellido 2", DateTime.UtcNow, "22223333", TipoGenero.Masculino);

            repositorio.IdentificacionYaRegistrada(Arg.Any<string>()).Returns(false);
            repositorio.Agregar(Arg.Any<Persona>()).Returns(persona);

            var id = await casoDeUso.Handle(comando);
            await repositorio.Received(1).Agregar(Arg.Any<Persona>());
            await unidadDeTrabajo.Received(1).Persistir();
            Assert.IsNotNull(id);
            Assert.AreEqual(id, persona.Id);
        }

        [TestMethod]
        public async Task Handle_CuandoHayError_HacemosRollback()
        {
            var comando = new ComandoAgregarPersona
            {
                Identificacion = "1112223334445",
                Nombres = "Nombre A",
                Apellidos = "Apellido 2",
                FechaNaciemiento = DateTime.UtcNow,
                Telefono = "22223333",
                Genero = TipoGenero.Masculino
            };

            repositorio.IdentificacionYaRegistrada(Arg.Any<string>()).Returns(false);
            repositorio.Agregar(Arg.Any<Persona>()).Throws<Exception>();

            await Assert.ThrowsExceptionAsync<Exception>( async () => await casoDeUso.Handle(comando));
            await unidadDeTrabajo.Received(1).Reversar();
        }
    }
}
