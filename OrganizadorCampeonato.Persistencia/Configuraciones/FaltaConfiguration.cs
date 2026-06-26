using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizadorCampeonato.Dominio.Entidades;
using System;

namespace OrganizadorCampeonato.Persistencia.Configuraciones
{
    public class FaltaConfiguration : IEntityTypeConfiguration<Falta>
    {
        public void Configure(EntityTypeBuilder<Falta> builder)
        {
            builder.HasOne(x => x.JugadorPartido)
                .WithMany(jp => jp.Faltas)
                .HasForeignKey(x => x.JugadorPartidoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(x => new { x.JugadorPartidoId, x.Periodo });
        }
    }
}
