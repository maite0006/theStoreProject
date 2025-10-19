using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.CustomExceptions.ArticuloExceptions
{
    public class ErrorFlujoArticulo: Exception
    {
        public ErrorFlujoArticulo(string mensaje) : base(mensaje)
        {
        }
    }
}
