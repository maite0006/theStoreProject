using Microsoft.EntityFrameworkCore;
using store.LogicaAplicacion.ICU.ICUArticulos;
using store.LogicaDatos;
using store.LogicaNegocio.CustomExceptions;
using store.LogicaNegocio.CustomExceptions.ArticuloExceptions;
using store.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUArticulos
{
    public class CUEditarCantArticulo : ICUEditarCantArt
    {
        private readonly eStoreDBContext _context;
        public CUEditarCantArticulo(eStoreDBContext context)
        {
            _context = context;
        }
        public async Task <bool> EditarCantidadArticulo(int articuloId, int nuevaCantidad)
        {
           Articulo articulo=  _context.Articulos.FirstOrDefault(a => a.Id == articuloId);
            if (articulo== null)
            {
                throw new EntityNotFound("Articulo", articuloId);
            }
            Producto producto = _context.Productos.FirstOrDefault(p => p.Id == articulo.ProductoId);
            if (producto == null)
            {
                throw new ErrorFlujoArticulo("El producto asociado al articulo no existe.");
            }
            if(nuevaCantidad < 0)
            {
                throw new CantidadArticuloInvalida("La cantidad solicitada no puede ser negativa.");
            }
            if (nuevaCantidad > producto.Stock)
            {
                throw new CantidadArticuloInvalida("La cantidad solicitada excede el stock disponible del producto.");
            }
            articulo.Cantidad += nuevaCantidad;
            _context.SaveChanges();
            return true;
        }
    }
}
