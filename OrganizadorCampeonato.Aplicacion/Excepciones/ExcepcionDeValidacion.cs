using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.Excepciones
{
    public class ExcepcionDeValidacion : Exception
    {
        public ExcepcionDeValidacion()
        {
        }

        public ExcepcionDeValidacion(string? message) : base(message)
        {
        }
    }
}
