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
    public class EntrenadorConfiguration : IEntityTypeConfiguration<Entrenador>
    {
        public void Configure(EntityTypeBuilder<Entrenador> builder)
        {
            builder.HasMany<Equipo>(e => e.Equipos)
                .WithOne(ep => ep.Entrenador)
                .HasForeignKey(e => e.EntrenadorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
