using store.DTOs.DTOs.Categoria;
using store.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.Mappers
{
    public class CategoriaMapper
    {
        public static CatDTO FromCatToDTO(Category cat)
        {
            CatDTO dto = new CatDTO()
            {
                id = cat.Id,
                nombre=cat.Nombre,
            };
            return dto;
        }
        public static Category FromDTOtoCat(CatDTO dto) 
        {
            Category cat = new Category()
            {
                Nombre = dto.nombre
            };
            return cat;
        
        }
    }
}
