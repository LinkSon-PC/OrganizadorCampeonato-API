using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Dominio.Entidades;
using System;

namespace OrganizadorCampeonato.Persistencia.Repositorios
{
    public class RepositorioFalta : Repositorio<Falta, Guid>, IRepositorioFalta
    {
        private readonly ApplicationDbContext context;

        public RepositorioFalta(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
