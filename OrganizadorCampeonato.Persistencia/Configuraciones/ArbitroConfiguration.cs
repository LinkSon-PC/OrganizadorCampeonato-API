using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrganizadorCampeonato.Dominio.Entidades;
using System;

namespace OrganizadorCampeonato.Persistencia.Configuraciones
{
    public class ArbitroConfiguration : IEntityTypeConfiguration<Arbitro>
    {
        public void Configure(EntityTypeBuilder<Arbitro> builder)
        {
        }
    }
}