using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Persistencia.Configuraciones
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.Property(x => x.Nombres)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Apellidos)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Identificacion)
                .IsRequired()
                .HasMaxLength(13);

            builder.HasIndex(x => x.Identificacion)
                .IsUnique();

            builder.Property(x => x.Telefono)
                .HasMaxLength(8);

            builder.HasOne(p => p.Jugador)
                   .WithOne(j => j.Persona)
                   .HasForeignKey<Jugador>(p => p.Id)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Entrenador)
                   .WithOne(j => j.Persona)
                   .HasForeignKey<Entrenador>(p => p.Id)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
