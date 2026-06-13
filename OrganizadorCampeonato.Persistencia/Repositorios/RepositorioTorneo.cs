using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Persistencia.Repositorios
{
    public class RepositorioTorneo : Repositorio<Torneo, Guid>, IRepositorioTorneo
    {
        private readonly ApplicationDbContext context;

        public RepositorioTorneo(ApplicationDbContext context) : base(context) 
        {
            this.context = context;
        }
    }
}
