using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizadorCampeonato.Dominio.Entidades;
using System;

namespace OrganizadorCampeonato.Persistencia.Configuraciones
{
    public class TorneoEquipoConfiguration : IEntityTypeConfiguration<TorneoEquipo>
    {
        public void Configure(EntityTypeBuilder<TorneoEquipo> builder)
        {
            builder.HasOne(x => x.Torneo)
                .WithMany(t => t.TorneoEquipos)
                .HasForeignKey(x => x.TorneoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Equipo)
                .WithMany(t => t.TorneoEquipos)
                .HasForeignKey(x => x.EquipoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(te => new { te.TorneoId, te.EquipoId }).IsUnique();
        }
    }
}
