using store.DTOs.DTOs.Articulo;
using store.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.Mappers
{
    public static class ArticuloCarritoMapper
    {
     
        
        public static ArticuloCarritoDTO FromEntity(ArticuloCarrito articulo)
        {
            return new ArticuloCarritoDTO
            {
                ArticuloId = articulo.Id,
                ProductoId = articulo.ProductoId,
                NombreProducto = articulo.Producto?.Nombre ?? string.Empty,
                Cantidad = articulo.Cantidad,
                PrecioUnitario = articulo.PrecioUnitario
            };
        }
    }
}
