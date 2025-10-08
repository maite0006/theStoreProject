using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.CustomExceptions.UserExceptions
{
    public class ExistingUser : DomainException
    {
        public ExistingUser(string email) : base($"El email'{email}' ya esta registrado. ")
        {
        }
    }
}
