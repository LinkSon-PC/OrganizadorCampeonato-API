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
    public class TorneoEquipoConfiguration : IEntityTypeConfiguration<TorneoEquipo>
    {
        public void Configure(EntityTypeBuilder<TorneoEquipo> builder)
        {
            builder.HasOne(x => x.Torneo)
                .WithMany(t => t.TorneoEquipo)
                .HasForeignKey(x => x.TorneoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Equipo)
                .WithMany(t => t.TorneoEquipo)
                .HasForeignKey(x => x.TorneoId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
