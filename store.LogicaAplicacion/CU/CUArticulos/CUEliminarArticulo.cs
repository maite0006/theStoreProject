using store.LogicaAplicacion.ICU.ICUArticulos;
using store.LogicaDatos;
using store.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUArticulos
{
    public  class CUEliminarArticulo : ICUEliminarArticulo
    {
        private readonly eStoreDBContext _context;
        public CUEliminarArticulo(eStoreDBContext context)
        {
            _context = context;
        }
        public void EliminarArticulo(int articuloId)
        {
            Articulo art= _context.Articulos.FirstOrDefault(a => a.Id == articuloId);
            if (art != null)
            {
                _context.Articulos.Remove(art);
                _context.SaveChanges();
            }


        }
    }
}
