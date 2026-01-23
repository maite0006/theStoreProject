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
    public class CUQuitarProdDestacado : ICUQuitarProductoDestacado

    {
        private readonly IRepositorioProductos _repo;

        public CUQuitarProdDestacado(IRepositorioProductos repo)
        {
            _repo = repo;
        }

        public async Task Ejecutar(int productoId)
        {
            var producto = await _repo.FindByIdAsync(productoId);

            if (producto == null)
                throw new EntityNotFound("Producto no encontrado");

            producto.QuitarDestacado(); 
            await _repo.UpdateAsync(producto);
        }
    }
}
