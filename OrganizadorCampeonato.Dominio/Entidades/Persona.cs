using OrganizadorCampeonato.Dominio.Comunes;
using OrganizadorCampeonato.Dominio.Enum;
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
        public string Identificacion { get; private set; }
        public string Nombres { get; private set; }
        public string Apellidos { get; private set; }
        public DateTime FechaNacimiento { get; private set; }
        public TipoGenero Genero { get; private set; }
        public string? Telefono { get; private set; }
        public Jugador? Jugador { get; private set; } = null;
        public Entrenador? Entrenador { get; private set; } = null;

        private Persona() { }

        public Persona(string identificacion, string nombre, string apellidos, DateTime fechaNacimiento, string telefono, TipoGenero genero)
        {
            ValidarNombres(nombre);
            ValidarApellidos(apellidos);
            ValidarIdentificacion(identificacion);
            ValidarTelefono(telefono);

            Identificacion = identificacion;
            Nombres = nombre;
            Apellidos = apellidos;
            FechaNacimiento = fechaNacimiento;
            Telefono = telefono;
            Genero = genero;

            Id = Guid.CreateVersion7();
        }

        private void ValidarNombres(string nombres)
        {
            if(string.IsNullOrWhiteSpace(nombres))
                throw new ExcepcionReglaDeNegocio($"El campo {Nombres.GetType().Name} es requerido");
        }

        private void ValidarApellidos(string apellidos)
        {
            if (string.IsNullOrWhiteSpace(apellidos))
                throw new ExcepcionReglaDeNegocio("Debe ingresar un Apellido");
        }

        private void ValidarIdentificacion(string identificacion)
        {
            if (string.IsNullOrEmpty(identificacion))
                throw new ExcepcionReglaDeNegocio($"El campo {identificacion.GetType().Name} es requerido");

            if (!long.TryParse(identificacion, out _) || identificacion.Length != 13)
                throw new ExcepcionReglaDeNegocio("Debe ingresar un número de identificación válido");
        }

        private void ValidarTelefono(string? telefono)
        {
            if (string.IsNullOrEmpty(telefono))
                return;

            if (!uint.TryParse(telefono, out _) || telefono.Length != 8)
                throw new ExcepcionReglaDeNegocio("Debe ingresar un número de teléfono válido");
        }

        public void SetIdentificacion(string identificacion)
        {
            ValidarIdentificacion(identificacion);
            Identificacion = Identificacion;
        }
        public void SetNombres(string nombres)
        {
            ValidarNombres(nombres);
            Nombres = nombres;
        }
        public void SetApellidos(string apellidos)
        {
            ValidarApellidos(apellidos);
            Apellidos = apellidos;
        }
        public void SetTelefono(string? telefono)
        {
            ValidarTelefono(telefono);
            Telefono = telefono;
        }
        public void SetFechaNacimiento(DateTime fechaNacimiento)
        {
            FechaNacimiento = fechaNacimiento;
        }
    }
}
