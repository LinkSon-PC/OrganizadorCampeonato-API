using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizadorCampeonato.Dominio.Entidades;
using System;

namespace OrganizadorCampeonato.Persistencia.Configuraciones
{
    public class PartidoEquipoConfiguration : IEntityTypeConfiguration<PartidoEquipo>
    {
        public void Configure(EntityTypeBuilder<PartidoEquipo> builder)
        {
            builder.HasOne(pe => pe.Partido)
                .WithMany(p => p.PartidoEquipos)
                .HasForeignKey(pe => pe.PartidoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(pe => pe.Equipo)
                .WithMany(e => e.PartidoEquipos)
                .HasForeignKey(pe => pe.EquipoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(pe => new { pe.PartidoId, pe.EquipoId })
                .IsUnique();
        }
    }
}