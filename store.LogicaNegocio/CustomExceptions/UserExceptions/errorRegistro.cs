using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.CustomExceptions.UserExceptions
{
    public class errorRegistro:Exception
    {
        public errorRegistro(string email) : base($"Error en el registro de usuario ")
        {
        }
    }
}
