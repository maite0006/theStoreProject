using store.DTOs.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.ICU.ICUUsuarios
{
    public interface ICUChangePass
    {
         Task ChangePass(string email, ChangePassDTO dto);

    }
}
