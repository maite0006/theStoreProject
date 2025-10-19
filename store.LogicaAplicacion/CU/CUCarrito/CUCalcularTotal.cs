using store.LogicaAplicacion.ICU.ICUCarrito;
using store.LogicaNegocio.Entidades;
using store.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUCarrito
{
    public class CUCalcularTotal : ICUCalcularTotal
    {
        private readonly IRepositorioPrecompras _repositorioPrecompras;
        public CUCalcularTotal(IRepositorioPrecompras repositorioPrecompras)
        {
            _repositorioPrecompras = repositorioPrecompras;
        }
        public async Task<decimal> CalcularTotalCarrito(int carritoId)
        {
            decimal total = 0;
            Precompra precompra= await _repositorioPrecompras.FindByIdAsync(carritoId);
            foreach (var art in precompra.Articulos)
            {
                // Validamos disponibilidad
                if (art.Producto.Activo && art.Cantidad <= art.Producto.Stock)
                {
                    total += art.Cantidad * art.PrecioUnitario;
                }
            }
             return total;
        } 
    }
}
