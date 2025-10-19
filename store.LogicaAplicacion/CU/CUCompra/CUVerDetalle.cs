using store.DTOs.DTOs.Compra;
using store.LogicaAplicacion.ICU.ICUCompra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUCompra
{
    public class CUVerDetalle : ICUVerDetalle
    {
        public Task<CompraDTO> VerDetalleCompra(int compraId)
        {
            throw new NotImplementedException();
        }
    }
}
