using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.CustomExceptions.UserExceptions
{
    public class NotExistingUser: Exception
    {
        public NotExistingUser(string email) : base($"No existe un usuario con el email: {email}")
        {
        }
    }
}
