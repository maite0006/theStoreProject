using store.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.ICU.ICUCompra.ICUPagos
{
    public interface ICUConfirmarPago
    {
        Task ConfirmarPago(int pagoId);
      
    }
}
