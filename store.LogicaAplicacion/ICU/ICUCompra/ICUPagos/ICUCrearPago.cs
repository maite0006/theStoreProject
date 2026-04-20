using store.DTOs.Pago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.ICU.ICUCompra.ICUPagos
{
    public interface ICUCrearPago
    {
        Task<String> Ejecutar(int compraId, CrearPagoDTO pago, int userId);
    }
}
