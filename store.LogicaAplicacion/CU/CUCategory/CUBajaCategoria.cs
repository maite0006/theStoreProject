using store.LogicaAplicacion.ICU.ICUCategory;
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
    public class CUBajaCategoria:ICUBajaCategoria
    {
        private readonly IRepositorioCategorias _repoCategorias;
        public CUBajaCategoria(IRepositorioCategorias repocats)
        {
            _repoCategorias = repocats;
        }
        public async Task<string> Eliminar(int id)
        {
            Category buscada = await _repoCategorias.FindByIdAsync(id);
            if (buscada == null)
            {
                throw new EntityNotFound("Categoria", id);
            }
            await _repoCategorias.RemoveAsync(id);
            return buscada.Nombre;
        }
    }
}
