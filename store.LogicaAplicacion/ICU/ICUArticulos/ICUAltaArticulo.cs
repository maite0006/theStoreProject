using store.DTOs.DTOs.Articulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.ICU.ICUArticulos
{
    public interface ICUAltaArticulo
    {
        Task<int> AltaArticulo(ArtDTO dto);
    }
}
