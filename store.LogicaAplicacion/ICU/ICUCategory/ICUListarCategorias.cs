using store.DTOs.DTOs.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.ICU.ICUCategory
{
    public interface ICUListarCategorias
    {
        Task<ICollection<CatDTO>> ListarCategorias();
    }
}
