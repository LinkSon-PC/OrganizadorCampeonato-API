using OrganizadorCampeonato.Dominio.Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.Contratos.Repositorios
{
    public interface IGenericRepository<T, TId>
        where T : EntidadAuditable<TId>
    {
        Task<T> Agregar(T entidad);
        Task<T?> ObtenerPorId(TId id);
        Task<IQueryable<T>> ObtenerTodos();
        Task Actualizar(T entidad);
        Task Borrar(T entidad);
        Task<int> ObtenerTotalRegistros();
    }
}
