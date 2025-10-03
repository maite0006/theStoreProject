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
    public class RepositorioReseñas : IRepositorioReseñas
    {
        private readonly eStoreDBContext _context;

        public RepositorioReseñas(eStoreDBContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(Reseña nuevo)
        {
            await _context.Reseñas.AddAsync(nuevo);
            await _context.SaveChangesAsync();
            return nuevo.Id;
        }

        public async  Task<List<Reseña>> FindAllAsync()
        {
            return await _context.Reseñas
            .Include(r => r.Cliente)
            .Include(r => r.Producto)
            .ToListAsync();
        }

        public async Task<ICollection<Reseña>> FindByCliente(Guid clienteGuid)
        {
            return await _context.Reseñas
            .Include(r => r.Producto)
            .Where(r => r.Cliente.Guid == clienteGuid)
            .ToListAsync();
        }

        public async Task<Reseña> FindByIdAsync(int id)
        {
            return await _context.Reseñas
            .Include(r => r.Cliente)
            .Include(r => r.Producto)
            .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<ICollection<Reseña>> FindByProducto(Guid productoGuid)
        {
            return await _context.Reseñas
             .Include(r => r.Cliente)
             .Where(r => r.Producto.Guid == productoGuid)
             .ToListAsync();
        }

        public async Task<ICollection<Reseña>> FindByRating(int min, int max)
        {
            return await _context.Reseñas
           .Include(r => r.Cliente)
           .Include(r => r.Producto)
           .Where(r => r.Puntuacion >= min && r.Puntuacion <= max)
           .ToListAsync();
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var reseña = await _context.Reseñas.FindAsync(id);
            if (reseña == null)
            {
                return false;
            }
           
            _context.Reseñas.Remove(reseña);
            await _context.SaveChangesAsync();
            return true;
            
        }

        public Task<bool> UpdateAsync(Reseña obj)
        {
            throw new NotSupportedException("Las reseñas no se pueden actualizar.");
        }
    }
}
