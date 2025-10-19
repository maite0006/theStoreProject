using store.DTOs.DTOs.Compra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.ICU.ICUCompra
{
    public interface ICUVerHistorial
    {
        Task<List<CompraDTO>> VerHistorialCompras(int usuarioId);
    }
}
