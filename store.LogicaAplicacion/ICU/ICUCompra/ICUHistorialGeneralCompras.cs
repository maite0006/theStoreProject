using store.DTOs.DTOs.Compra;
using store.LogicaAplicacion.Mappers;
using store.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.ICU.ICUCompra
{
    public interface ICUHistorialGeneralCompras
    {
        Task<List<CompraDTO>> HistorialGeneral();
        Task<List<CompraDTO>> HistorialComprasbyFecha(DateTime min, DateTime max);
        Task<List<CompraDTO>> HistorialComprasbyEstadoEnvio( string estado);
        Task<List<CompraDTO>> HistorialComprasPending();
    }
}
