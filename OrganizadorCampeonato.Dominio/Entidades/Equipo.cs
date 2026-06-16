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

        public string Nombre { get; init; }
        public Guid? EntrenadorId { get; init; }
        public Guid? CategoriaId { get; init; }
        public Entrenador? Entrenador { get; init; } = null!;
        public Categoria? Categoria { get; init; } = null!;
        public List<TorneoEquipo> TorneoEquipos { get; init; } = new();
        public List<PartidoEquipo> PartidoEquipos { get; init; } = new();
        public List<EquipoJugador> EquipoJugadores { get; init; } = new();

        private void ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ExcepcionReglaDeNegocio($"El campo {Nombre.GetType().Name} es requerido");
        }

    }
}
