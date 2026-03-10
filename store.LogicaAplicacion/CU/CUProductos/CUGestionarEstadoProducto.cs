using store.LogicaAplicacion.ICU.ICUProductos;
using store.LogicaNegocio.CustomExceptions;
using store.LogicaNegocio.CustomExceptions.ProdExceptions;
using store.LogicaNegocio.Entidades;
using store.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUProductos
{
    public class CUGestionarEstadoProducto : ICUGestionarEstadoProducto
    {
        private readonly IRepositorioProductos _repositorioProductos;
        private readonly IRepositorioUsuarios _repositorioUsuarios;
        public CUGestionarEstadoProducto(IRepositorioProductos repositorioProductos)
        {
            _repositorioProductos = repositorioProductos;
            
        }
        public async Task ejecutar(Guid GUID, bool activo)
        {
            Producto producto = await _repositorioProductos.FindByGuid(GUID);

            if (producto == null)
                throw new EntityNotFound("Producto", GUID);

            if (producto.Activo == activo)
                throw new AccionInvalida("Este producto ya se encuentra en el estado seleccionado.");

            producto.Activo = activo;

            await _repositorioProductos.UpdateAsync(producto);
        }

       
    }
}
