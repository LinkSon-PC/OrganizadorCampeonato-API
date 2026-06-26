using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Dominio.Entidades;
using System;

namespace OrganizadorCampeonato.Persistencia.Repositorios
{
    public class RepositorioJugadorPartido : Repositorio<JugadorPartido, Guid>, IRepositorioJugadorPartido
    {
        private readonly ApplicationDbContext context;

        public RepositorioJugadorPartido(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
