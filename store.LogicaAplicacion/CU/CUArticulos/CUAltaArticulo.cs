using store.DTOs.DTOs.Articulo;
using store.LogicaAplicacion.ICU.ICUArticulos;
using store.LogicaDatos;
using store.LogicaNegocio.CustomExceptions;
using store.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUArticulos
{
    public class CUAltaArticulo : ICUAltaArticulo
    {
        private readonly eStoreDBContext _context;
        public CUAltaArticulo(eStoreDBContext context)
        {
            _context = context;
        }
        public async Task<int> AltaArticulo(ArtDTO dto)
        {
            Articulo articulo = Mappers.ArticuloMapper.FromDTO(dto);
            
            
            if (articulo == null)
            {
                throw new ArgumentException("El ArtDTO proporcionado no es válido.");
            }
            _context.Articulos.Add(articulo);
            if(dto.compraId != null)
            {
                bool ExisteArt = _context.Articulos.Any(a => a.ProductoId == dto.productoId && a.CompraId == dto.compraId);
                if (ExisteArt)
                    throw new AlreadyExistingEntity("Articulo");
                Compra compra =  _context.Compras.FirstOrDefault(c => c.Id == dto.compraId.Value);
               
                if (compra == null)
                    throw new EntityNotFound("Compra", dto.compraId.Value);

                articulo.CompraId = compra.Id;

            }
            else if(dto.precompraId != null)
            {
                bool ExisteArt = _context.Articulos.Any(a => a.ProductoId == dto.productoId && a.PrecompraId == dto.precompraId);
                if (ExisteArt)
                    throw new AlreadyExistingEntity("Articulo");
                Precompra precompra = _context.Precompras.FirstOrDefault(p => p.Id == dto.precompraId.Value);
                if (precompra == null)
                    throw new EntityNotFound("Precompra", dto.precompraId.Value);

                articulo.PrecompraId = precompra.Id; // ya establece la FK
            }
            
            _context.SaveChanges();
            return articulo.Id;

        }
    }
}
