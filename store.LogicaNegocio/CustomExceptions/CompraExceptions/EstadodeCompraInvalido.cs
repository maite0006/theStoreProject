using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.CustomExceptions.CompraExceptions
{
    public class EstadodeCompraInvalido : DomainException
    {
        public EstadodeCompraInvalido(string message) : base(message)
        {
        }
    }
}
