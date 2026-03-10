using store.DTOs.DTOs.Compra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.ICU.ICUCompra.ICUEnvio
{
    public interface ICUListarEnvios
    {
        Task<List<EnvioDTO>> HistorialEnvios();
        Task<List<EnvioDTO>> HistorialEnviosU(int usuarioId);
        Task<List<EnvioDTO>> HistorialEnviosUNF(int usuarioId);
        Task<List<EnvioDTO>> HistorialEnviosNF();

    }
}
