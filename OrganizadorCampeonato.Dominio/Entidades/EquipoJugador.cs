using OrganizadorCampeonato.Dominio.Comunes;
using System;

namespace OrganizadorCampeonato.Dominio.Entidades
{
    public class EquipoJugador : EntidadAuditable<Guid>
    {
        private EquipoJugador() { }

        public EquipoJugador(Guid id, Guid equipoId, Guid jugadorId) : base(id)
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

        public Guid EquipoId { get; init; }
        public Guid JugadorId { get; init; }
        public DateTime FechaIncorporacion { get; init; }
        public bool EstaActivo { get; init; }

        public Equipo Equipo { get; init; } = null!;
        public Jugador Jugador { get; init; } = null!;
    }
}