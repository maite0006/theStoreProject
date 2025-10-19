using store.DTOs.DTOs.Carrito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.ICU.ICUCarrito
{
    public interface ICUVerCarrito
    {
        Task<CarritoDTO> VerCarrito(int usuarioId);
    }
}
