using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorCampeonato.Dominio.Excepciones
{
    public class ExcepcionReglaDeNegocio : Exception
    {
        public ExcepcionReglaDeNegocio()
        {
        }

        public ExcepcionReglaDeNegocio(string? message) : base(message)
        {
        }
    }
}
