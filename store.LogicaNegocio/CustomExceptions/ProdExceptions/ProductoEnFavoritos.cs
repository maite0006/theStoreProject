using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.CustomExceptions.ProdExceptions
{
    public class ProductoEnFavoritos : DomainException
    {
        public ProductoEnFavoritos(string message) : base(message)
        {
        }
    }
}
