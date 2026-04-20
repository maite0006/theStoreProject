using store.LogicaAplicacion.ICU.ICUCarrito;
using store.LogicaNegocio.CustomExceptions;
using store.LogicaNegocio.CustomExceptions.ArticuloExceptions;
using store.LogicaNegocio.Entidades;
using store.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUCarrito
{
    public class CUVaciarCarrito : ICUVaciarCarrito
    {
        private readonly IRepositorioPrecompras _repoCarrito;

        public CUVaciarCarrito(IRepositorioPrecompras repoCarrito)
        {
            _repoCarrito = repoCarrito;
        }

        public async Task Vaciar(int usuarioId)
        {
          
            Precompra carrito = await _repoCarrito.FindByCliente(usuarioId);

            if (carrito == null)
                throw new EntityNotFound("Carrito", usuarioId);
            if (!carrito.Articulos.Any())
                throw new ErrorFlujoArticulo("El carrito ya está vacío");
            carrito.Vaciar();
            await _repoCarrito.UpdateAsync(carrito);
        }
    }

}
