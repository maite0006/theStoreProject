using store.DTOs.DTOs.Categoria;
using store.LogicaAplicacion.ICU.ICUCategory;
using store.LogicaAplicacion.Mappers;
using store.LogicaNegocio.Entidades;
using store.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUCategory
{
    public class CUListarCategorias:ICUListarCategorias
    {
        private readonly IRepositorioCategorias _repoCategorias;
        public CUListarCategorias(IRepositorioCategorias repocats)
        {
            _repoCategorias = repocats;
        }
        public async Task<ICollection<CatDTO>> ListarCategorias() 
        { 
            ICollection<CatDTO> dtos= new List<CatDTO>();
            ICollection<Category> cats= await _repoCategorias.FindAllAsync();
            foreach (var cat in cats)
            {
                CatDTO dto = CategoriaMapper.FromCatToDTO(cat);
                dtos.Add(dto);
                
            }
            return dtos;

        }
    }
}
