using store.DTOs.DTOs.Compra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.ICU.ICUCompra.ICUEnvio
{
    public interface ICUVerDetalleEnvio
    {
        EnvioDTO Ejecutar(int id);
    }
}
