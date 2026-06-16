using OrganizadorCampeonato.Dominio.Comunes;
using System;

namespace OrganizadorCampeonato.Dominio.Entidades
{
    public class EquipoJugador : EntidadAuditable<Guid>
    {
        private EquipoJugador() { }

        public EquipoJugador(Guid equipoId, Guid jugadorId)
        {
            if (equipoId == Guid.Empty)
                throw new ArgumentException("El equipo es requerido", nameof(equipoId));
            if (jugadorId == Guid.Empty)
                throw new ArgumentException("El jugador es requerido", nameof(jugadorId));

            EquipoId = equipoId;
            JugadorId = jugadorId;
            FechaIncorporacion = DateTime.UtcNow;
            EstaActivo = true;
        }

        public Guid EquipoId { get; private set; }
        public Guid JugadorId { get; private set; }
        public DateTime FechaIncorporacion { get; private set; }
        public bool EstaActivo { get; private set; }

        public Equipo Equipo { get; private set; } = null!;
        public Jugador Jugador { get; private set; } = null!;

        public void Desactivar()
        {
            EstaActivo = false;
        }

        public void Activar()
        {
            EstaActivo = true;
        }
    }
}