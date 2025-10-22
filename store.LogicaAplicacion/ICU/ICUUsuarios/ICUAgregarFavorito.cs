using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.ICU.ICUUsuarios
{
    public interface ICUAgregarFavorito
    {
        Task<bool> AgregarProductoFavorito(int userId, Guid prodGuid);
    }
}
