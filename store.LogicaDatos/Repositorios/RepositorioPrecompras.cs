using Microsoft.EntityFrameworkCore;
using store.LogicaNegocio.Entidades;
using store.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaDatos.Repositorios
{
    public class RepositorioPrecompras : IRepositorioPrecompras
    {
        private readonly eStoreDBContext _context;

        public RepositorioPrecompras(eStoreDBContext context)
        {
            _context = context;
        }

        public async Task AddArticulo(Articulo art)
        {
            var precompra = await _context.Precompras
            .Include(pc => pc.Articulos)
            .FirstOrDefaultAsync(pc => pc.Id == art.PrecompraId);

            if (precompra != null)
            {
                precompra.Articulos.Add(art); 
                await _context.Articulos.AddAsync(art); 
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> AddAsync(Precompra nuevo)
        {
            await _context.Precompras.AddAsync(nuevo);
            await _context.SaveChangesAsync();
            return nuevo.Id;
        }

        public async Task<List<Precompra>> FindAllAsync()
        {
            return await _context.Precompras
            .Include(pc => pc.Articulos)
            .ToListAsync();
        }

        public async Task<Precompra> FindByCliente(int clienteid)
        {
            return await _context.Precompras
            .Include(pc => pc.Articulos)
            .FirstOrDefaultAsync(pc => pc.Cliente.Id == clienteid);
        }

        public async Task<Precompra> FindByIdAsync(int id)
        {
            return await _context.Precompras
           .Include(pc => pc.Articulos)
           .FirstOrDefaultAsync(pc => pc.Id == id);
        }
        public async Task<bool> RemoveArticulo(int articuloId)
        {
            var art = await _context.Articulos.FindAsync(articuloId);
            if (art == null) return false;

            _context.Articulos.Remove(art);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var art = await _context.Articulos.FindAsync(id);
            if (art == null) return false;

            _context.Articulos.Remove(art);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Precompra obj)
        {
            return false;
        }
        public async Task<ICollection<Articulo>> GetArticulos(int clienteid)
        {
            var precompra = await _context.Precompras
            .Include(pc => pc.Articulos)
            .FirstOrDefaultAsync(pc => pc.Cliente.Id == clienteid);

            return precompra?.Articulos ?? new List<Articulo>();

        }

      
    }
}
