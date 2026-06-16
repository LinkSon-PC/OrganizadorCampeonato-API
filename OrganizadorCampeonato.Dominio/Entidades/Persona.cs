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
        public string Identificacion { get; init; }
        public string Nombres { get; init; }
        public string Apellidos { get; init; }
        public DateTime FechaNacimiento { get; init; }
        public TipoGenero Genero { get; init; }
        public string? Telefono { get; init; }
        public Jugador? Jugador { get; init; } = null;
        public Entrenador? Entrenador { get; init; } = null;
        public Arbitro? Arbitro { get; init; } = null;

        private Persona() { }

        public Persona(Guid id, string identificacion, string nombres, string apellidos, DateTime fechaNacimiento, string telefono, TipoGenero genero) : base(id)
        {
            ValidarNombres(nombres);
            ValidarApellidos(apellidos);
            ValidarIdentificacion(identificacion);
            ValidarTelefono(telefono);

            Identificacion = identificacion;
            Nombres = nombres;
            Apellidos = apellidos;
            FechaNacimiento = fechaNacimiento;
            Telefono = telefono;
            Genero = genero;
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
            if (string.IsNullOrWhiteSpace(telefono))
                return;

            if (!uint.TryParse(telefono, out _) || telefono.Length != 8)
                throw new ExcepcionReglaDeNegocio("Debe ingresar un número de teléfono válido");
        }

    }
}
