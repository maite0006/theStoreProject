using store.LogicaAplicacion.ICU.ICUCarrito;
using store.LogicaDatos.Repositorios;
using store.LogicaNegocio.CustomExceptions;
using store.LogicaNegocio.CustomExceptions.PrecompraException;
using store.LogicaNegocio.Entidades;
using store.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUCarrito
{
    public class CUCerrarPrecompra : ICUCerrarPrecompra
    {
        private readonly IRepositorioPrecompras _repositorioPrecompras;
        private readonly ICUCalcularTotal _cuCalcularTotalCarrito;
        public  CUCerrarPrecompra(IRepositorioPrecompras repositorio, ICUCalcularTotal cUCalcularTotal)
        {
            _repositorioPrecompras = repositorio;
            _cuCalcularTotalCarrito = cUCalcularTotal;
        }
        //Terminar metodo
        public async Task<bool> CerrarPrecompra(int precompraId)
        {
            // 1. Recuperar la precompra del usuario con los artículos y productos
            Precompra precompra = await _repositorioPrecompras.FindByIdAsync(precompraId);
            if (precompra == null || precompra.Articulos.Count == 0)
                throw new EntityNotFound("Precompra", precompraId);

            // 2. Separar artículos válidos de los inválidos
            var articulosValidos = precompra.Articulos
                .Where(a => a.Producto.Activo && a.Cantidad <= a.Producto.Stock)
                .ToList();

            if (!articulosValidos.Any())
                throw new SinArticulosDisponibles("No hay artículos disponibles para la compra.");

            
            var articulosInvalidos = precompra.Articulos.Except(articulosValidos).ToList();

            var compra = new Compra
            {
                ClienteId = precompra.ClienteId,
                Articulos = articulosValidos,
                Total = articulosValidos.Sum(a => a.Cantidad * a.PrecioUnitario),
                Fecha = DateTime.Now,
           
            };

            // Llamar al CU de realizar compra para persistir la compra y actualizar stock
            int compraId = await _cuRealizarCompra.RealizarCompra(compra);

            
            precompra.Articulos.Clear();
            await _repositorioPrecompras.UpdateAsync(precompra);

            return true;
        }
    }
}
