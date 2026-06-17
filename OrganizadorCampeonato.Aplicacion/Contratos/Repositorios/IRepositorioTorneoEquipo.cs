using OrganizadorCampeonato.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.Contratos.Repositorios
{
    public interface IRepositorioTorneoEquipo : IGenericRepository<TorneoEquipo, Guid>
    {
        Task<IQueryable<TorneoEquipo>> ObtenerTodosEquipoTorneo(Guid id);
        Task<TorneoEquipo?> ObtenerPorTorneoYEquipo(Guid torneoId, Guid equipoId);
        Task<bool> ExisteInscripcion(Guid torneoId, Guid equipoId);
    }
}
