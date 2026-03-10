using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.CustomExceptions.ProdExceptions
{
    public class AccionInvalida:Exception
    {
        public AccionInvalida(string mensaje) : base($"La accion es invalida: {mensaje}")
        {
        }
    }
}
