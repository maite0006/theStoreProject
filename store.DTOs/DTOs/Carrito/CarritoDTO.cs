using store.DTOs.DTOs.Articulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.DTOs.DTOs.Carrito
{
    public class CarritoDTO
    {
        public int PrecompraId { get; set; }
        public List<ArticuloCarritoDTO> Articulos { get; set; } = new();
        public decimal Total { get; set; }
    }
}
