using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.DTOs.DTOs.User
{
    public class ChangePassDTO
    {
        [Required]
        public string passActual  { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "El campo Nueva Contraseña debe tener al menos 8 caracteres")]
        public string newPass { get; set; }
        [Required]
        [Compare("newPass", ErrorMessage = "Las contraseñas no coinciden")]
        [MinLength(8, ErrorMessage = "El campo Confirmar Nueva Contraseña debe tener al menos 8 caracteres")]
        public string confirmNewPass { get; set; }

    }
}
