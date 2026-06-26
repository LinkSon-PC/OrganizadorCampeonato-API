using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizadorCampeonato.Dominio.Entidades;
using System;

namespace OrganizadorCampeonato.Persistencia.Configuraciones
{
    public class OficialPartidoConfiguration : IEntityTypeConfiguration<OficialPartido>
    {
        public void Configure(EntityTypeBuilder<OficialPartido> builder)
        {
            builder.HasOne(x => x.Partido)
                .WithMany(p => p.OficialesPartido)
                .HasForeignKey(x => x.PartidoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Arbitro)
                .WithMany(a => a.OficialesPartido)
                .HasForeignKey(x => x.ArbitroId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(x => new { x.PartidoId, x.Rol }).IsUnique();
        }
    }
}
