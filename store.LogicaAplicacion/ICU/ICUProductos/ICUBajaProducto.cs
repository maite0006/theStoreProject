using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.ICU.ICUProductos
{
    public interface ICUBajaProducto
    {
        Task<bool> EliminarProd(Guid productoGuid, int admId);
    }
}
