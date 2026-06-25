using OrganizadorCampeonato.Dominio.Comunes;
using OrganizadorCampeonato.Dominio.Enum;
using System;
using System.Collections.Generic;

namespace OrganizadorCampeonato.Dominio.Entidades
{
    public class TorneoEquipo : EntidadAuditable<Guid>
    {
        private TorneoEquipo() { }

        public TorneoEquipo(Guid id, Guid torneoId, Guid equipoId, int? posicion = null) : base(id)
        {
            TorneoId = torneoId;
            EquipoId = equipoId;
            Posicion = posicion;
            FechaInscripcion = DateTime.UtcNow;
            Estado = EstadoInscripcion.Pendiente;
        }

        public Guid TorneoId { get; init; }
        public Guid EquipoId { get; init; }
        public DateTime FechaInscripcion { get; init; }
        public EstadoInscripcion Estado { get; init; }
        public int? Posicion { get; init; }

        public Torneo Torneo { get; init; } = null!;
        public Equipo Equipo { get; init; } = null!;
    }
}
