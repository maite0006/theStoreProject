using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.ICU.ICUArticulos
{
    public interface ICUEditarCantArt
    {
        Task<bool> EditarCantidadArticulo(int articuloId, int nuevaCantidad);
    }
}
