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
                .HasMaxLength(13);

            builder.Property(x => x.Telefono)
                .HasMaxLength(8);
        }
    }
}
