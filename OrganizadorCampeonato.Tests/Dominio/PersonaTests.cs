using OrganizadorCampeonato.Dominio.Entidades;
using OrganizadorCampeonato.Dominio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Tests.Dominio
{
    [TestClass]
    public class PersonaTests
    {

        [TestMethod]
        public void CrearPersona_Exitoso()
        {
            var persona = new Persona("1112223334445","Nombre A","Apellido 2", DateTime.UtcNow, "22223333");

            Assert.IsNotNull(persona);
            Assert.IsNotNull(persona.Id);
            Assert.AreEqual("Nombre A", persona.Nombres);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionReglaDeNegocio))]  
        public void CrearPersona_LanzaExcepcionValidacionIdentificacion()
        {
            var persona = new Persona("", "Nombre A", "Apellido 2", DateTime.UtcNow, "22223333");
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionReglaDeNegocio))]
        public void CrearPersona_LanzaExcepcionValidacionTelefono()
        {
            var persona = new Persona("1112223334445", "Nombre A", "Apellido 2", DateTime.UtcNow, "222a23333");
        }
    }
}
