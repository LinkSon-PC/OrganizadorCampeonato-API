using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizadorCampeonato.Dominio.Entidades;
using System;

namespace OrganizadorCampeonato.Persistencia.Configuraciones
{
    public class TiempoMuertoConfiguration : IEntityTypeConfiguration<TiempoMuerto>
    {
        public void Configure(EntityTypeBuilder<TiempoMuerto> builder)
        {
            builder.HasOne(x => x.Partido)
                .WithMany(p => p.TiemposMuertos)
                .HasForeignKey(x => x.PartidoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Equipo)
                .WithMany()
                .HasForeignKey(x => x.EquipoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(x => new { x.PartidoId, x.EquipoId, x.EsPrimeraMitad });
        }
    }
}
