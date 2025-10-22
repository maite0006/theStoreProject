using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.ICU.ICUUsuarios
{
    public interface ICUEliminarFavorito
    {
        Task EliminarProductoFavorito(int userId, Guid prodGuid);
    }
}
