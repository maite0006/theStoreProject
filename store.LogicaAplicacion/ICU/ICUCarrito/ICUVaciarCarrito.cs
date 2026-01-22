using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.ICU.ICUCarrito
{
    public interface ICUVaciarCarrito
    {
        Task Vaciar(int usuarioId);
    }
}
