using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace store.DTOs.DTOs.Articulo
{
    public class ArtDTO
    {
        public int cantidad { get; set; }
        public decimal precioUnitario { get; set; }
        public int productoId { get; set; }
        public int? compraId { get; set; }
        public int? precompraId { get; set; }

    }
}
