using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.DTOs.DTOs.User.Authorization
{
    public class LoginDTO
    {
        [Required (ErrorMessage = "El campo Email es obligatorio")]
        public string? Email { get; set; }
        [Required (ErrorMessage = "El campo Contraseña es obligatorio")]
        [MinLength(8, ErrorMessage = "El campo Contraseña debe tener al menos 8 caracteres")]
        public string? password { get; set; }
    }
}
