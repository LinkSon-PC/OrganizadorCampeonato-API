using OrganizadorCampeonato.Dominio.Comunes;
using OrganizadorCampeonato.Dominio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Dominio.Entidades
{
    public class Equipo : EntidadAuditable<Guid>
    {
        public Equipo() { }
        public Equipo(string nombre, Guid entrenadorId)
        {
            ValidarNombre(nombre);

            Nombre = nombre;
            EntrenadorId = entrenadorId;
        }

        public string Nombre { get; private set; }
        public Guid EntrenadorId { get; private set; }
        public Entrenador Entrenador { get; private set; }
        public List<TorneoEquipo> TorneoEquipo { get; private set; }

        private void ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ExcepcionReglaDeNegocio($"El campo {Nombre.GetType().Name} es requerido");
        }
    }
}
