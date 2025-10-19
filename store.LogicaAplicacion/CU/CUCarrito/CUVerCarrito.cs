using store.DTOs.DTOs.Articulo;
using store.DTOs.DTOs.Carrito;
using store.LogicaAplicacion.ICU.ICUCarrito;
using store.LogicaNegocio.CustomExceptions;
using store.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUCarrito
{
    public class CUVerCarrito : ICUVerCarrito
    {
        private readonly IRepositorioPrecompras _repositorio;
        private readonly ICUCalcularTotal _cuCalcularTotalCarrito;

        public CUVerCarrito(IRepositorioPrecompras repositorio, ICUCalcularTotal cUCalcularTotal)
        {
            _repositorio = repositorio;
            _cuCalcularTotalCarrito = cUCalcularTotal;
        }
        public async Task<CarritoDTO> VerCarrito(int usuarioId)
        {
            var precompra = await _repositorio.FindByCliente(usuarioId);

            if (precompra == null)
                throw new EntityNotFound("Precompra");

            var carritoDto = new CarritoDTO
            {
                 PrecompraId= precompra.Id,
                Total =  await _cuCalcularTotalCarrito.CalcularTotalCarrito(precompra.Id),
            };

            foreach (var art in precompra.Articulos)
            {
                var disponible = art.Producto.Activo && art.Cantidad <= art.Producto.Stock;

                carritoDto.Articulos.Add(new ArticuloCarritoDTO
                {
                    ArticuloId = art.Id,
                    ProductoId = art.ProductoId,
                    NombreProducto = art.Producto.Nombre,
                    Cantidad = art.Cantidad,
                    PrecioUnitario = art.PrecioUnitario,
                    Disponible = disponible
                });
            }

            return carritoDto;
        }
    }
    
}
