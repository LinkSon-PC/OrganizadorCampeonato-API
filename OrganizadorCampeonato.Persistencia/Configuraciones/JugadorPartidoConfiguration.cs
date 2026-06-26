using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizadorCampeonato.Dominio.Entidades;
using System;

namespace OrganizadorCampeonato.Persistencia.Configuraciones
{
    public class JugadorPartidoConfiguration : IEntityTypeConfiguration<JugadorPartido>
    {
        public void Configure(EntityTypeBuilder<JugadorPartido> builder)
        {
            builder.HasOne(x => x.PartidoEquipo)
                .WithMany()
                .HasForeignKey(x => x.PartidoEquipoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Jugador)
                .WithMany()
                .HasForeignKey(x => x.JugadorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(x => new { x.PartidoEquipoId, x.JugadorId }).IsUnique();
        }
    }
}
