using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.CustomExceptions.UserExceptions
{
    public class IncorrectPassword: Exception
    {
        public IncorrectPassword() : base($"La contraseña es incorrecta.")
        {
        }
    }
}
