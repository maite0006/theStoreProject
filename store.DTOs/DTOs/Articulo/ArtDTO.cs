using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace store.DTOs.DTOs.Articulo
{
    public class ArtDTO
    {
        [Required]
        [Range(1, 20, ErrorMessage = "La cantidad debe estar entre 1 y 20 unidades.")]
        public int cantidad { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal precioUnitario { get; set; }

        [Required]
        public int productoId { get; set; }

        public int? compraId { get; set; }
        public int? precompraId { get; set; }

    }
}
