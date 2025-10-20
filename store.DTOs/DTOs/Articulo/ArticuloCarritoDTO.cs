using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.DTOs.DTOs.Articulo
{
    public class ArticuloCarritoDTO
    {
        public int ArticuloId { get; set; }
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string Disponible { get; set; }

        public ArticuloCarritoDTO(int articuloId, int productoId, string nombreProducto, int cantidad, decimal precioUnitario)
        {
            ArticuloId = articuloId;
            ProductoId = productoId;
            NombreProducto = nombreProducto;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
          
        }
    }
}
