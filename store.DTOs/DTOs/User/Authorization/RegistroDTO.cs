using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.DTOs.DTOs.User.Authorization
{
    public class RegistroDTO
    {
        [Required(ErrorMessage = "El campo Email es obligatorio")]
        [EmailAddress(ErrorMessage = "El campo Email no es una dirección de correo electrónico válida")]
        public string? Email{ get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [MinLength(3, ErrorMessage = "El campo Nombre debe tener al menos 3 caracteres")]
        public string? name{ get; set; }

        [Required(ErrorMessage = "El campo Contraseña es obligatorio")]
        [MinLength(8, ErrorMessage = "El campo Contraseña debe tener al menos 8 caracteres")]
        public string? password{ get; set; }
        [Required(ErrorMessage = "El campo Confirmar Contraseña es obligatorio")]
        [Compare("password", ErrorMessage = "Las contraseñas no coinciden")]
        public string? confirmPassword{ get; set; }
        [Required(ErrorMessage = "El campo País es obligatorio")]
        public string? pais{ get; set; }
        [Required(ErrorMessage = "El campo Teléfono es obligatorio")]
        [Phone(ErrorMessage = "El campo Teléfono no es un número de teléfono válido")]
        public string? telefono{ get; set; }

    }
}
