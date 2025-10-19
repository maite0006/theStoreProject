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
    }
}
