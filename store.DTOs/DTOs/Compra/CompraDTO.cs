using store.DTOs.DTOs.Articulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.DTOs.DTOs.Compra
{
    public class CompraDTO
    {
        public int? CompraId { get; set; }
        public List<ArticuloCarritoDTO> Articulos { get; set; } = new();
        public decimal Total { get; set; }
        public string EstadoCompra { get; set; }
        public PagoDTO? Pago { get; set; }
        public EnvioDTO? Envio { get; set; }

    }
}
