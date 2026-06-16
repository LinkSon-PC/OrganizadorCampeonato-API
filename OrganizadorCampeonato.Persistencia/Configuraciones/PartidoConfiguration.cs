using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizadorCampeonato.Dominio.Entidades;
using System;

namespace OrganizadorCampeonato.Persistencia.Configuraciones
{
    public class PartidoConfiguration : IEntityTypeConfiguration<Partido>
    {
        public void Configure(EntityTypeBuilder<Partido> builder)
        {
            builder.Property(p => p.Lugar)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Grupo)
                .HasMaxLength(50);

            builder.Property(p => p.PuntosLocal_P1).HasPrecision(5, 0);
            builder.Property(p => p.PuntosVisitante_P1).HasPrecision(5, 0);
            builder.Property(p => p.PuntosLocal_P2).HasPrecision(5, 0);
            builder.Property(p => p.PuntosVisitante_P2).HasPrecision(5, 0);
            builder.Property(p => p.PuntosLocal_P3).HasPrecision(5, 0);
            builder.Property(p => p.PuntosVisitante_P3).HasPrecision(5, 0);
            builder.Property(p => p.PuntosLocal_P4).HasPrecision(5, 0);
            builder.Property(p => p.PuntosVisitante_P4).HasPrecision(5, 0);
            builder.Property(p => p.PuntosLocal_Prorroga).HasPrecision(5, 0);
            builder.Property(p => p.PuntosVisitante_Prorroga).HasPrecision(5, 0);

            builder.HasOne(p => p.Torneo)
                .WithMany(t => t.Partidos)
                .HasForeignKey(p => p.TorneoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Ganador)
                .WithMany()
                .HasForeignKey(p => p.GanadorId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(p => p.FechaHora);
            builder.HasIndex(p => p.Estado);
        }
    }
}