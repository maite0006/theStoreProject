using store.DTOs.DTOs.Compra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.ICU.ICUCompra.ICUPagos
{
    public interface ICUCrearPago
    {
        Task<int> Ejecutar(int compraId, PagoDTO pago);
    }
}
