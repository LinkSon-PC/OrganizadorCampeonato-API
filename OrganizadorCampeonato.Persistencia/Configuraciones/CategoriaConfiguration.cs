using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Persistencia.Configuraciones
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasMany(c => c.Torneos)
                .WithOne(t => t.Categoria)
                .HasForeignKey(c => c.CategoriaId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(c => c.Equipos)
                .WithOne(e => e.Categoria)
                .HasForeignKey(e => e.CategoriaId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
