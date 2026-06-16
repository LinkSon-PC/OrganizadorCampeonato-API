using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizadorCampeonato.Dominio.Entidades;
using System;

namespace OrganizadorCampeonato.Persistencia.Configuraciones
{
    public class PartidoArbitroConfiguration : IEntityTypeConfiguration<PartidoArbitro>
    {
        public void Configure(EntityTypeBuilder<PartidoArbitro> builder)
        {
            builder.Property(p => p.Rol)
                .HasMaxLength(50);

            builder.HasOne(pa => pa.Partido)
                .WithMany(p => p.PartidoArbitros)
                .HasForeignKey(pa => pa.PartidoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(pa => pa.Arbitro)
                .WithMany(a => a.PartidoArbitros)
                .HasForeignKey(pa => pa.ArbitroId)
                .HasPrincipalKey(a => a.Id)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}