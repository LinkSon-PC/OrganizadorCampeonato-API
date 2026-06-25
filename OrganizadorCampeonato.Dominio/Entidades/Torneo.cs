using OrganizadorCampeonato.Dominio.Comunes;
using OrganizadorCampeonato.Dominio.Enum;
using OrganizadorCampeonato.Dominio.Excepciones;
using System;
using System.Collections.Generic;

namespace OrganizadorCampeonato.Dominio.Entidades
{
    public class Torneo : EntidadAuditable<Guid>
    {
        private Torneo() { }
        public Torneo(Guid id, string nombre, string lugar, Guid categoriaId, FormatoTorneo formato, DateTime inicio, DateTime fin, string descripcion = "") : base(id)
        {
            ValidarNombre(nombre);
            ValidarLugar(lugar);
            ValidarFechas(inicio, fin);

            Nombre = nombre.Trim();
            Lugar = lugar.Trim();
            Descripcion = descripcion.Trim();
            CategoriaId = categoriaId;
            Formato = formato;
            FechaInicio = inicio;
            FechaFin = fin;
            Estado = EstadoTorneo.Planificado;
        }

        public string Nombre { get; init; }
        public string Lugar { get; init; }
        public string? Descripcion { get; init; }
        public Guid CategoriaId { get; init; }
        public FormatoTorneo Formato { get; init; }
        public DateTime FechaInicio { get; init; }
        public DateTime FechaFin { get; init; }
        public EstadoTorneo Estado { get; init; }
        public Categoria? Categoria { get; init; }
        public List<TorneoEquipo> TorneoEquipos { get; init; } = new();
        public List<Partido> Partidos { get; init; } = new();

        private void ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ExcepcionReglaDeNegocio("El nombre del torneo es requerido");
        }

        private void ValidarLugar(string lugar)
        {
            if (string.IsNullOrWhiteSpace(lugar))
                throw new ExcepcionReglaDeNegocio("El lugar del torneo es requerido");
        }

        private void ValidarFechas(DateTime inicio, DateTime fin)
        {
            if (inicio > fin)
                throw new ExcepcionReglaDeNegocio("Fecha de inicio no puede ser mayor que fecha fin");
        }
    }
}
