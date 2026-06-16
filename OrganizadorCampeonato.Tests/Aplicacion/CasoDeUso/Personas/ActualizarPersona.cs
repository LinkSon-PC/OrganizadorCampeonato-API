using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using OrganizadorCampeonato.Aplicacion.CasosDeUso.Personas.Comandos.ActualizarPersona;
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
    public class ActualizarPersona
    {
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
        private IRepositorioPersona repositorio;
        private IUnidadDeTrabajo unidadDeTrabajo;
        private CasoDeUsoActualizarPersona casoDeUso;
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.

        [TestInitialize]
        public void Initial()
        {
            repositorio = Substitute.For<IRepositorioPersona>();
            unidadDeTrabajo = Substitute.For<IUnidadDeTrabajo>();
            casoDeUso = new CasoDeUsoActualizarPersona(repositorio, unidadDeTrabajo);
        }

        [TestMethod]
        public async Task Handle_Exitoso()
        {
            var persona = new Persona(Guid.CreateVersion7(), "1112223334445", "Nombre A", "Apellido 2", DateTime.UtcNow, "22223333", TipoGenero.Masculino);
            var comando = new ComandoActualizarPersona
            {
                Id = persona.Id,
                Identificacion = "1112223334445",
                Nombres = "Nombre A",
                Apellidos = "Apellido 2",
                Genero = TipoGenero.Masculino,
                FechaNaciemiento = DateTime.UtcNow,
                Telefono = "22223333"
            };

            repositorio.ObtenerPorId(Arg.Any<Guid>()).Returns(persona);

            await casoDeUso.Handle(comando);
            await repositorio.Received(1).Actualizar(Arg.Any<Persona>());
            await unidadDeTrabajo.Received(1).Persistir();

        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionDeValidacion))]
        public async Task Handle_CuandoNoSeEncuentre_LanzaExcepcion()
        {
            var comando = new ComandoActualizarPersona
            {
                Id = new Guid(),
                Identificacion = "1112223334445",
                Nombres = "Nombre A",
                Apellidos = "Apellido 2",
                Genero = TipoGenero.Masculino,
                FechaNaciemiento = DateTime.UtcNow,
                Telefono = "22223333"
            };
            repositorio.ObtenerPorId(comando.Id).ReturnsNull();

            await casoDeUso.Handle(comando);
        }


        [TestMethod]
        public async Task Handle_CuandoHayError_HacemosRollback()
        {
            var persona = new Persona(Guid.CreateVersion7(), "1112223334445", "Nombre A", "Apellido 2", DateTime.UtcNow, "22223333", TipoGenero.Masculino);
            var comando = new ComandoActualizarPersona
            {
                Id = persona.Id,
                Identificacion = "1112223334445",
                Nombres = "Nombre A",
                Apellidos = "Apellido 2",
                Genero = TipoGenero.Masculino,
                FechaNaciemiento = DateTime.UtcNow,
                Telefono = "22223333"
            };

            repositorio.ObtenerPorId(Arg.Any<Guid>()).Returns(persona);
            repositorio.Actualizar(Arg.Any<Persona>()).Throws<Exception>();

            await Assert.ThrowsExceptionAsync<Exception>(async () => await casoDeUso.Handle(comando));
            await unidadDeTrabajo.Received(1).Reversar();
        }
    }
}
