using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.DTOs.DTOs.Producto
{
    public class ProdDTO
    {

        
        [Required]
        public string Nombre { get; set; }
        [Required]
        [RegularExpression("^(tapiz|cuadro|poster)$",
        ErrorMessage = "El tipo debe ser 'tapiz', 'cuadro' o 'poster'.")]
        public string Tipo { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public string Medidas { get; set; }
        public List<string> ImagenesUrls { get; set; }
        public List<int> Categorias { get; set; }
        //tapiz
        public string? TipoTela { get; set; }
        public string? Grosor { get; set; }
        //cuadro
        public string? Autor { get; set; }
        public string? Lienzo { get; set; }
        //poster
        public string? TipoPapel { get; set; }
        public string? Acabado { get; set; }
    }
}
