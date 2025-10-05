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
    public class RepositorioCategorias : IRepositorioCategorias
    {
        private readonly eStoreDBContext _context;

        public RepositorioCategorias(eStoreDBContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Category nuevo)
        {
            await _context.Categories.AddAsync(nuevo);
            await _context.SaveChangesAsync();
            return nuevo.Id; 
        }

        public async Task<List<Category>> FindAllAsync()
        {
            return await _context.Categories
            .Include(c=> c.Productos) // Incluir los productos relacionados
            .ToListAsync();
        }

        public async Task<Category> FindByIdAsync(int id)
        {
            return await _context.Categories
                .Include(c => c.Productos) // Incluir los productos relacionados
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category> FindByName(string nombre)
        {
            return await _context.Categories
                .Include(c => c.Productos) // Incluir los productos relacionados
                .FirstOrDefaultAsync(c => c.Nombre == nombre);
        }

        public async Task<ICollection<Category>> FindByProducto(Guid productoGuid)
        {
           return await _context.Categories
                .Where(c => c.Productos.Any(p => p.Guid == productoGuid))
                .ToListAsync();
        }

        public async Task<bool> RemoveAsync(int id)
        {
           return await _context.Categories
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Category obj)
        {
            return await Task.Run(() =>
            {
                _context.Categories.Update(obj);
                return _context.SaveChanges() > 0;
            });
        }
    }
}
