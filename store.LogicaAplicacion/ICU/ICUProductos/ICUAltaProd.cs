using store.DTOs.DTOs.Producto;
using store.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.ICU.ICUProductos
{
    public interface ICUAltaProd
    {
        Task<AltaProdOutDTO> AgregarP(AltaProdInDTO dto);
        Task<AltaProdOutDTO> MapearCatsGuardar(Producto producto, List<int> categorias);

    }
}
