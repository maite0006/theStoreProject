using store.DTOs.DTOs.User;
using store.DTOs.DTOs.User.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.ICU.ICUUsuarios
{
    public interface IAuthorizations
    {
        Task<UserOutputDTO> RegistrarAsync(RegistroDTO dto);
        Task<UserOutputDTO> LoginAsync(LoginDTO dto);

    }
}
