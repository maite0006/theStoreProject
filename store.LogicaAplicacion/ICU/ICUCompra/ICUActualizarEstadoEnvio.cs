using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.ICU.ICUCompra
{
    public interface ICUActualizarEstadoEnvio
    {
        Task<bool> ActualizarEstadoEnvio(int compraId, string nuevoEstado);
    }
}
