using OrganizadorCampeonato.Dominio.Comunes;
using OrganizadorCampeonato.Dominio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Dominio.Entidades
{
    public class Persona : EntidadAuditable<Guid>
    {
        private Persona() { }

        public Persona(string identificacion, string nombre, string apellidos, DateTime fechaNacimiento, string telefono)
        {
            ValidarIdentificacion(identificacion);
            ValidarTelefono(telefono);

            Identificacion = identificacion;
            Nombres = nombre;
            Apellidos = apellidos;
            FechaNaciemiento = fechaNacimiento;
            Telefono = telefono;

            Id = Guid.CreateVersion7();
        }

        private void ValidarIdentificacion(string identifiacacion)
        {
            if (uint.TryParse(identifiacacion, out _) && identifiacacion.Length != 13)
                throw new ExcepcionReglaDeNegocio("Debe ingresar un número de identificación válido");
        }

        private void ValidarTelefono(string telefono)
        {
            if (uint.TryParse(telefono, out _) && telefono.Length != 8)
                throw new ExcepcionReglaDeNegocio("Debe ingresar un número de teléfono válido");
        }

        public string Identificacion { get; private set; }
        public string Nombres { get; private set; }
        public string Apellidos { get; private set; }
        public DateTime FechaNaciemiento { get; private set; }
        public string Telefono { get; private set; }
    }
}
