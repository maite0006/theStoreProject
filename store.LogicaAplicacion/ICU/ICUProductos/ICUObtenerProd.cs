using store.DTOs.DTOs.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.ICU.ICUProductos
{
    public interface ICUObtenerProd
    {
         Task<ProdDTO> ObtenerProdbyID(int id);
        
    }
}
