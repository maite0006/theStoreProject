using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.ICU.ICUUsuarios
{
    internal interface ICUAgregarFavorito
    {
        Task<bool> AgregarProductoFavorito(Guid prodGuid);
    }
}
