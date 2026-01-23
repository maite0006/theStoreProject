using store.LogicaAplicacion.ICU.ICUProductos;
using store.LogicaNegocio.CustomExceptions;
using store.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUProductos
{
    public class CUMarcarProductoDestacado : ICUMarcarProductoDestacado
    {
        
            private readonly IRepositorioProductos _repo;

            public CUMarcarProductoDestacado(IRepositorioProductos repo)
            {
                _repo = repo;
            }

            public async Task Ejecutar(int productoId)
            {
                var producto = await _repo.FindByIdAsync(productoId);

                if (producto == null)
                    throw new EntityNotFound("Producto", productoId);

                producto.MarcarComoDestacado();

                await _repo.UpdateAsync(producto);
            }
    }
}
