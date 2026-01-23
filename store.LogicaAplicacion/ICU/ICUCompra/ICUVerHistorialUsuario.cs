using store.DTOs.DTOs.Compra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.ICU.ICUCompra
{
    public interface ICUVerHistorialUsuario
    {
        Task<List<CompraDTO>> HistorialComprasU(int usuarioId);
        Task<List<CompraDTO>> HistorialComprasbyFechaU(int usuarioId, DateTime min, DateTime max);
        Task<List<CompraDTO>> HistorialComprasbyEstadoU(int usuarioId, string estado);
        Task<List<CompraDTO>> HistorialComprasPendingU(int usuarioId);
    }
}
