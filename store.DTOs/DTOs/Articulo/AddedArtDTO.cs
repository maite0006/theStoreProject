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
    public class AddedArtDTO
    {
        [Required]
        public int ProductoId { get; set; }

        [Required]
        [Range(1, 20)]
        public int Cantidad { get; set; }
    }
}
