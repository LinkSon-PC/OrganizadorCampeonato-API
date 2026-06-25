using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizadorCampeonato.Dominio.Entidades;
using System;

namespace OrganizadorCampeonato.Persistencia.Configuraciones
{
    public class ResultadoPeriodoConfiguration : IEntityTypeConfiguration<ResultadoPeriodo>
    {
        public void Configure(EntityTypeBuilder<ResultadoPeriodo> builder)
        {
            builder.HasOne(rp => rp.Partido)
                .WithMany(p => p.ResultadosPeriodos)
                .HasForeignKey(rp => rp.PartidoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(rp => new { rp.PartidoId, rp.Periodo, rp.NumeroProrroga }).IsUnique();
        }
    }
}