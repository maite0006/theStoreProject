using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.CustomExceptions
{
    public class EntityNotFound : Exception
    {
        public EntityNotFound(string entityName, int identifier)
        : base($"La entidad '{entityName}' con Id '{identifier}' no fue encontrada.")
        {
        }

        public EntityNotFound(string entityName, Guid guid)
            : base($"La entidad '{entityName}' con Guid '{guid}' no fue encontrada.")
        {
        }

        public EntityNotFound(string entityName)
            : base($"La entidad '{entityName}' no fue encontrada.")
        {
        }
    }
}