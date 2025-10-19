using store.DTOs.DTOs.Articulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.ICU.ICUCarrito
{
    public interface ICUAgregaralCarrito
    {
        Task<bool> AgregarAlCarrito(ArtDTO art);
    }
}
