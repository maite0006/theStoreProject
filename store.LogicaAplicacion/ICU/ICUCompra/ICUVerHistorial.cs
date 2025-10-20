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
        Task<List<CompraDTO>> HistorialCompras(int usuarioId);
        Task<List<CompraDTO>> HistorialComprasbyFecha(int usuarioId, DateTime min, DateTime max);
        Task<List<CompraDTO>> HistorialComprasbyEstado(int usuarioId, string estado);
        Task<List<CompraDTO>> HistorialComprasPending(int usuarioId);
    }
}
