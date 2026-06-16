using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizadorCampeonato.Dominio.Entidades;
using OrganizadorCampeonato.Persistencia.Conversores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Persistencia.Configuraciones
{
    public class EquipoConfiguration : IEntityTypeConfiguration<Equipo>
    {
        public void Configure(EntityTypeBuilder<Equipo> builder)
        {
            builder.Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasOne(e => e.Entrenador)
                .WithMany(en => en.Equipos)
                .HasForeignKey(e => e.EntrenadorId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.Categoria)
                .WithMany(c => c.Equipos)
                .HasForeignKey(e => e.CategoriaId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(x => x.Nombre);
        }
    }
}
