using store.LogicaAplicacion.ICU.ICUProductos;
using store.LogicaNegocio.CustomExceptions;
using store.LogicaNegocio.Entidades;
using store.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUProductos
{
    public class CUBajaProd : ICUBajaProd
    {
        private readonly IRepositorioProductos _repositorioProductos;
        public CUBajaProd(IRepositorioProductos repositorioProductos)
        {
            _repositorioProductos = repositorioProductos;
        }
        public async Task<bool> BajaProductoAsync(Guid productoGuid)
        {
           Producto prod= await _repositorioProductos.FindByGuid(productoGuid);
            
              if (prod == null)
              {
                throw new EntityNotFound("Producto", productoGuid);
              }
              prod.Activo = false;
              return await _repositorioProductos.UpdateAsync(prod);
        }
        public async Task<bool> EliminarProd(Guid productoGuid)
        {
            Producto prod = await _repositorioProductos.FindByGuid(productoGuid);
            if (prod == null)
            {
                throw new EntityNotFound("Producto", productoGuid);
            }
           _repositorioProductos.RemoveAsync(prod.Id);
            return await _repositorioProductos.UpdateAsync(prod);
        }
    }
}
