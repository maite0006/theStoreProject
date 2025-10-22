using store.DTOs.DTOs.Articulo;
using store.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.Mappers
{
    public class ArticuloMapper
    {
        public static Articulo FromDTO(ArtDTO dto)
        {
            if (dto.compraId != null)
            {
                Articulo ret = new Articulo(dto.productoId, dto.cantidad, dto.precioUnitario, dto.compraId.Value, true);
              
                return ret;
            }
            if(dto.precompraId != null)
            {
                Articulo ret = new Articulo(dto.productoId, dto.cantidad, dto.precioUnitario, dto.precompraId.Value);
               
                return ret;
            }
            return null;


        }
        public static ArticuloCarritoDTO fromArticulo(Articulo articulo)
        {
            ArticuloCarritoDTO ret = new(articulo.Id, articulo.Producto.Id, articulo.Producto.Nombre, articulo.Cantidad, articulo.PrecioUnitario);
            if (articulo.Producto.Activo && articulo.Producto.Stock > articulo.Cantidad)
                ret.Disponible = "Disponible";
            if(!articulo.Producto.Activo)
                ret.Disponible = "Articulo no disponible";
            if (articulo.Cantidad > articulo.Producto.Stock)
                ret.Disponible = "Stock insuficiente para la cantidad seleccionada";
            return ret;
        }
    }
}
