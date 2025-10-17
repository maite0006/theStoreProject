using store.DTOs.DTOs.User;
using store.LogicaAplicacion.ICU.ICUUsuarios;
using store.LogicaNegocio.CustomExceptions.UserExceptions;
using store.LogicaNegocio.IRepositorios;
using store.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUUsuarios
{
    public class CUChangePass:ICUChangePass
    {
        private readonly IRepositorioUsuarios _repousers;
        public CUChangePass(IRepositorioUsuarios repo)
        {
            _repousers = repo;
        }
        public async Task ChangePass(string email, ChangePassDTO dto)
        {
            var usuario = await _repousers.FindByEmail(email);
            if (usuario == null) throw new NotExistingUser(email);
            if (dto.newPass != dto.confirmNewPass) throw new PasswordsDontMatch();
            bool passwordMatch = Crypto.VerifyPasswordConBcrypt(dto.passActual, usuario.Password);
            if (passwordMatch)
            {
                usuario.Password = Crypto.HashPasswordConBcrypt(dto.newPass, 12);
                bool updated = await _repousers.UpdateAsync(usuario);
                if (!updated) throw new Exception("Error updating password");
              
            }
            else
            {
                throw new IncorrectPassword();
               

            }

        }
    }   
}
