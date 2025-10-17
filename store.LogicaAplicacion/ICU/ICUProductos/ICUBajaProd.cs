using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.ICU.ICUProductos
{
    public interface ICUBajaProd
    {
        Task<bool> BajaProductoAsync(Guid productoGuid);
        Task<bool> EliminarProd(Guid productoGuid);
    }
}
