using store.DTOs.DTOs.Carrito;
using store.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.Mappers
{
    public class CarritoMapper
    {
        public static CarritoDTO FromEntity(Precompra precompra)
        {
            return new CarritoDTO
            {
                Total = precompra.Total,
                Articulos = precompra.Articulos
                    .Select(ArticuloCarritoMapper.FromEntity)
                    .ToList()
            };
        }
    }
}
