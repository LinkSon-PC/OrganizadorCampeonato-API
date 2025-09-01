using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Aplicacion.Excepciones
{
    public class ExcepcionDeMediador : Exception
    {
        public ExcepcionDeMediador(string mensaje) : base(mensaje)
        {
        }
    }
}
