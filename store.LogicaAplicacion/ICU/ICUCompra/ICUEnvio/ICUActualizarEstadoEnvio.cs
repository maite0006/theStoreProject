using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.ICU.ICUCompra.ICUEnvio
{
    public interface ICUActualizarEstadoEnvio
    {
        Task<bool> ActualizarEstadoEnvio(int compraId, string nuevoEstado);
    }
}
