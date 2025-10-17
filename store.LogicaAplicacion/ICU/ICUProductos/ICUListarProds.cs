using store.DTOs.DTOs.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.ICU.ICUProductos
{
    public interface ICUListarProds
    {
        Task<ICollection<ProdDTO>> obtenerTodos();
        Task<ICollection<ProdDTO>> obtenerActivos();
        Task<ICollection<ProdDTO>> obtenerbyPriceRange(int min, int max);
        Task<ICollection<ProdDTO>> obtenerbyNameOrDescription(string texto);
        Task<ICollection<ProdDTO>> obtenerbyCategoria(string categoria);
        Task<ICollection<ProdDTO>> obtenerbytype(string type);

    }
}
