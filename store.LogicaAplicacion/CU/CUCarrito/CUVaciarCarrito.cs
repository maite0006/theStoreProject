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
            // 1. obtener carrito activo del usuario
            Precompra carrito = await _repoCarrito.FindByCliente(usuarioId);

            if (carrito == null)
                throw new EntityNotFound("Carrito", usuarioId);

            // 2. regla de dominio
            if (!carrito.Articulos.Any())
                throw new ErrorFlujoArticulo("El carrito ya está vacío");

            // 3. operación de dominio
            carrito.Vaciar();

            // 4. persistencia
            await _repoCarrito.UpdateAsync(carrito);
        }
    }

}
