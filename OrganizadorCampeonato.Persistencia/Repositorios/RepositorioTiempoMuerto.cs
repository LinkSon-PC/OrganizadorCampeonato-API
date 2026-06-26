using OrganizadorCampeonato.Aplicacion.Contratos.Repositorios;
using OrganizadorCampeonato.Dominio.Entidades;
using System;

namespace OrganizadorCampeonato.Persistencia.Repositorios
{
    public class RepositorioTiempoMuerto : Repositorio<TiempoMuerto, Guid>, IRepositorioTiempoMuerto
    {
        private readonly ApplicationDbContext context;

        public RepositorioTiempoMuerto(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
