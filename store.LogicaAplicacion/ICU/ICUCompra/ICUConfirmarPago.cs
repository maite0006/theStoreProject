using store.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.ICU.ICUCompra
{
    public interface ICUConfirmarPago
    {
        Task<bool> ConfirmarPago(int CompraID);
        bool SimulacionMP(Pago p);
    }
}
