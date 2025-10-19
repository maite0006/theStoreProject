using Microsoft.Identity.Client.Extensibility;
using store.DTOs.DTOs.Compra;
using store.LogicaAplicacion.ICU.ICUCompra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUCompra
{
    public class CUVerHistorial : ICUVerHistorial
    {
        public Task<List<CompraDTO>> VerHistorialCompras(int usuarioId)
        {
            throw new NotImplementedException();
        }
    }
}
