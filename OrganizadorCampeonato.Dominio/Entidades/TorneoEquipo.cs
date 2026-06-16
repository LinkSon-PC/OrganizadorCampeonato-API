using OrganizadorCampeonato.Dominio.Comunes;
using OrganizadorCampeonato.Dominio.Enum;
using System;
using System.Collections.Generic;

namespace OrganizadorCampeonato.Dominio.Entidades
{
    public class TorneoEquipo : EntidadAuditable<Guid>
    {
        private TorneoEquipo() { }

        public TorneoEquipo(Guid torneoId, Guid equipoId, int? posicion = null)
        {
            TorneoId = torneoId;
            EquipoId = equipoId;
            Posicion = posicion;
            FechaInscripcion = DateTime.UtcNow;
            Estado = EstadoInscripcion.Inscrito;
        }

        public Guid TorneoId { get; private set; }
        public Guid EquipoId { get; private set; }
        public DateTime FechaInscripcion { get; private set; }
        public EstadoInscripcion Estado { get; private set; }
        public int? Posicion { get; private set; }

        public Torneo Torneo { get; private set; } = null!;
        public Equipo Equipo { get; private set; } = null!;

        public void MarcarEliminado()
        {
            Estado = EstadoInscripcion.Eliminado;
        }

        public void MarcarCampeon()
        {
            Estado = EstadoInscripcion.Campeon;
        }

        public void ActualizarPosicion(int? posicion)
        {
            Posicion = posicion;
        }
    }
}
