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
            if (PageNumber < 1)
                throw new ArgumentException("PageNumber debe ser mayor o igual a 1", nameof(PageNumber));

            if (PageSize < 1)
                throw new ArgumentException("PageSize debe ser mayor o igual a 1", nameof(PageSize));

            return query.Skip((PageNumber - 1) * PageSize).Take(PageSize);
        }
    }
}
