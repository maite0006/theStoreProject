
using store.DTOs.DTOs.Compra;
using store.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.ICU.ICUCompra
{
    public interface ICUConfigurarCompra
    {
        Task<int> ConfiguraciónCompra(int compraId, PagoDTO dtoPago, EnvioDTO dtoEnvio);
    }
}
