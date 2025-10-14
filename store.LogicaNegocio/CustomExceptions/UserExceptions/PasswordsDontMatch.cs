using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.CustomExceptions.UserExceptions
{
    public class PasswordsDontMatch: Exception
    {
        public PasswordsDontMatch() : base("Las contraseñas no coinciden.") { }
    }
}
