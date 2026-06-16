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
        public Equipo(Guid id, string nombre, Guid? entrenadorId, Guid? categoriaId) : base(id)
        {
            ValidarNombre(nombre);

            Nombre = nombre;
            EntrenadorId = entrenadorId;
            CategoriaId = categoriaId;
        }

        public string Nombre { get; private set; }
        public Guid? EntrenadorId { get; private set; }
        public Guid? CategoriaId { get; private set; }
        public Entrenador? Entrenador { get; private set; } = null!;
        public Categoria? Categoria { get; private set; } = null!;
        public List<TorneoEquipo> TorneoEquipos { get; private set; } = new();
        public List<PartidoEquipo> PartidoEquipos { get; private set; } = new();
        public List<EquipoJugador> EquipoJugadores { get; private set; } = new();

        private void ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ExcepcionReglaDeNegocio($"El campo {Nombre.GetType().Name} es requerido");
        }

        public void ActualizarNombre(string nombre)
        {
            ValidarNombre(nombre);

            Nombre = nombre;
        }
        public void ActualizarEntrenadorId(Guid? entrenadorId)
        {
            EntrenadorId = entrenadorId;
        }
        public void ActualizarCategoria(Guid? categoriaId)
        {
            CategoriaId = categoriaId;
        }
    }
}
