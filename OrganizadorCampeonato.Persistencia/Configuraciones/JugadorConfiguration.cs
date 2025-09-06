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
    public class JugadorConfiguration : IEntityTypeConfiguration<Jugador>
    {
        public void Configure(EntityTypeBuilder<Jugador> builder)
        {
        }
    }
}
