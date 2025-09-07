using OrganizadorCampeonato.Dominio.Comunes;
using OrganizadorCampeonato.Dominio.Enum;
using OrganizadorCampeonato.Dominio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Dominio.Entidades
{
    public class Torneo : EntidadAuditable<Guid>
    {
        private Torneo() { }
        public Torneo(string nombre, string lugar, Guid categoriaId, FormatoTorneo formato, DateTime inicio, DateTime fin, string descripcion = "")
        {
            ValidarNombre(nombre);
            ValidarLugar(lugar);
            ValidarFechas(inicio,fin);

            Nombre = nombre.Trim();
            Lugar = lugar.Trim();
            Descripcion = descripcion.Trim();
            CategoriaId = categoriaId;
            Formato = formato;
            FechaInicio = inicio;
            FechaFin = fin;
        }

        public string Nombre { get; private set; }
        public string Lugar { get; private set; }
        public string? Descripcion { get; private set; }
        public Guid? CategoriaId { get; private set; }
        public FormatoTorneo Formato {  get; private set; }
        public DateTime FechaInicio { get; private set; }
        public DateTime FechaFin { get; private set; }
        public Categoria? Categoria { get; private set; }
        public List<TorneoEquipo> TorneoEquipo { get; private set; }


        private void ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ExcepcionReglaDeNegocio($"El campo {Nombre.GetType().Name} es requerido");
        }
        private void ValidarLugar(string lugar)
        {
            if (string.IsNullOrWhiteSpace(lugar))
                throw new ExcepcionReglaDeNegocio($"El campo {Lugar.GetType().Name} es requerido");
        }
        private void ValidarFechas(DateTime inicio, DateTime fin)
        {
            if (inicio < fin)
                throw new ExcepcionReglaDeNegocio("Fecha de incio no puede ser menor que fecha fin");

            if(inicio < DateTime.UtcNow)
                throw new ExcepcionReglaDeNegocio("Fecha incio no puede ser menor a fecha actual");
        }
    }
}
