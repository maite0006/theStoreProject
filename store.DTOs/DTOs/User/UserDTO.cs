using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.DTOs.DTOs.User
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Rol { get; set; }
    }
}
