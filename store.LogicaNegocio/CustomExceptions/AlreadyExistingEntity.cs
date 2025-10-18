using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.CustomExceptions
{
    public class AlreadyExistingEntity: DomainException
    {
        public AlreadyExistingEntity(string entity):base($"La entidad{entity} intentada dar de alta ya existe. ")
        {

        }
    }
}
