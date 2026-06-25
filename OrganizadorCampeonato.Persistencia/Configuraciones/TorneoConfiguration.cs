using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizadorCampeonato.Dominio.Entidades;
using System;

namespace OrganizadorCampeonato.Persistencia.Configuraciones
{
    public class TorneoConfiguration : IEntityTypeConfiguration<Torneo>
    {
        public void Configure(EntityTypeBuilder<Torneo> builder)
        {
            builder.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.Lugar)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Descripcion)
                .HasMaxLength(250);

            builder.HasOne(t => t.Categoria)
                .WithMany(c => c.Torneos)
                .HasForeignKey(t => t.CategoriaId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(t => t.CategoriaId);
            builder.HasIndex(t => t.FechaInicio);
            builder.HasIndex(t => t.Formato);
        }
    }
}
