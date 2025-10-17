using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.CustomExceptions.ProdExceptions
{
    public class ProdInvalido: Exception
    {
        public ProdInvalido(string mensaje) : base($"El producto es invalido: {mensaje}")
        {
        }
    }
}
