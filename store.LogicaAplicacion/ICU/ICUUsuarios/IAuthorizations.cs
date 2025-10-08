using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.ICU.ICUUsuarios
{
    public interface IAuthorizations
    {
        Task<bool> RegistrarAsync(string nombre, string email, string password, string pais, string telefono);
        Task<string> LoginAsync(string username, string password);

    }
}
