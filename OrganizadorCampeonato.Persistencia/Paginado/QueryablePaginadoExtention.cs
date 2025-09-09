using System;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Persistencia.Paginado
{
    public static class QueryablePaginadoExtention
    {
        public static IQueryable<T> Paginado<T>(
            this IQueryable<T> query,
            int PageNumber,
            int PageSize
        ) 
        {
            return query.Skip((PageNumber - 1) * PageSize).Take(PageSize);
        }
    }
}
