using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.DTOs.DTOs.Categoria
{
    public class CatDTO
    {
        public int? id {  get; set; }
        [Required]
        [MinLength(3)]
        public string nombre { get; set; }
    }
}
