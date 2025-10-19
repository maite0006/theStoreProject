using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.CustomExceptions.PrecompraException
{
    public class SinArticulosDisponibles: Exception
    {
        public SinArticulosDisponibles(string mensaje) : base(mensaje)
        {
        }
    }
}
