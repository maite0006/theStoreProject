using store.DTOs.DTOs.Categoria;
using store.LogicaAplicacion.ICU.ICUCategory;
using store.LogicaAplicacion.Mappers;
using store.LogicaNegocio.CustomExceptions;
using store.LogicaNegocio.Entidades;
using store.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUCategory
{
    public class CUAltaCategoria : ICUAltaCategoria
    {
        private readonly IRepositorioCategorias _repoCategorias;
        public CUAltaCategoria(IRepositorioCategorias repocategoria)
        {
            _repoCategorias = repocategoria;
        }
        public async Task<CatDTO> AltaCategoria(CatDTO dto)
        {
            Category buscada = await _repoCategorias.FindByName(dto.nombre);
            if (buscada != null)
            {
                throw new AlreadyExistingEntity("Categoria");
            }
            Category cat= CategoriaMapper.FromDTOtoCat(dto);
            await _repoCategorias.AddAsync(cat);
            return CategoriaMapper.FromCatToDTO(cat);
             

        }
    }
}
