using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizadorCampeonato.Dominio.Entidades;
using System;

namespace OrganizadorCampeonato.Persistencia.Configuraciones
{
    public class EquipoJugadorConfiguration : IEntityTypeConfiguration<EquipoJugador>
    {
        public void Configure(EntityTypeBuilder<EquipoJugador> builder)
        {
            builder.HasOne(ej => ej.Equipo)
                .WithMany(e => e.EquipoJugadores)
                .HasForeignKey(ej => ej.EquipoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ej => ej.Jugador)
                .WithMany(j => j.EquipoJugadores)
                .HasForeignKey(ej => ej.JugadorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(ej => new { ej.EquipoId, ej.JugadorId })
                .IsUnique();
        }
    }
}