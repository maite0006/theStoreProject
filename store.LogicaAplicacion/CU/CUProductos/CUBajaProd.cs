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
        private readonly IRepositorioUsuarios _repositorioUsuarios;
        public CUBajaProd(IRepositorioProductos repositorioProductos, IRepositorioUsuarios repositorioUsuarios)
        {
            _repositorioProductos = repositorioProductos;
            _repositorioUsuarios = repositorioUsuarios;
        }
        public async Task<bool> BajaProductoAsync(Guid productoGuid)
        {
           Producto prod= await _repositorioProductos.FindByGuid(productoGuid);

            if (prod == null)
                throw new EntityNotFound("Producto", productoGuid);
              
              prod.Activo = false;
              return await _repositorioProductos.UpdateAsync(prod);
        }
        public async Task<bool> EliminarProd(Guid productoGuid, int admID)
        {
            Producto prod = await _repositorioProductos.FindByGuid(productoGuid);
            Administrador adm = (Administrador)await _repositorioUsuarios.FindByIdAsync(admID);
            if (adm == null)
                throw new EntityNotFound("Administrador", admID);
            if (prod == null)
                throw new EntityNotFound("Producto", productoGuid);
             adm.EliminarProducto(productoGuid);
            await _repositorioProductos.RemoveAsync(prod.Id);
            return await _repositorioProductos.UpdateAsync(prod);
        }
    }
}
