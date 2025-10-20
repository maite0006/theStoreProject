using store.DTOs.DTOs.Compra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.ICU.ICUCarrito
{
    public interface ICUCerrarPrecompra
    {
        Task<CompraDTO> CerrarPrecompra(int precompraId);
    }
}
