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

            builder.HasOne(p => p.Torneo)
                .WithMany(t => t.Partidos)
                .HasForeignKey(p => p.TorneoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Ignore(p => p.PuntosLocal);
            builder.Ignore(p => p.PuntosVisitante);

            builder.HasIndex(p => p.FechaHora);
            builder.HasIndex(p => p.Estado);
            builder.HasIndex(p => p.TorneoId);
        }
    }
}