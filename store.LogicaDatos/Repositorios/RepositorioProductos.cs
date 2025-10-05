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
    public class RepositorioProductos : IRepositorioProductos
    {
        private readonly eStoreDBContext _context;

        public RepositorioProductos(eStoreDBContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(Producto nuevo)
        {
            
            await _context.Productos.AddAsync(nuevo);
            await _context.SaveChangesAsync();
            return nuevo.Id;
        }

        public async Task<List<Producto>> FindAllAsync()
        {
            return await _context.Productos
            .Include(p => p.Categorias)
            .ToListAsync();
        }

        public async Task<ICollection<Producto>> FindAvailable()
        {
            return await _context.Productos
            .Where(p => p.Activo)
            .ToListAsync();
        }

        public async Task<ICollection<Producto>> FindByCategoria(string categoria)
        {
            return await _context.Productos
            .Where(p => p.Categorias.Any(c => c.Nombre == categoria))
            .ToListAsync();
        }

        public async Task<Producto> FindByGuid(Guid guid)
        {
            return await _context.Productos
             .Include(p => p.Categorias)
             .FirstOrDefaultAsync(p => p.Guid == guid);
        }

        public async Task<Producto> FindByIdAsync(Guid id)
        {
            return await _context.Productos
            .Include(p => p.Categorias)
            .FirstOrDefaultAsync(p => p.Guid == id);
        }

        public async Task<ICollection<Producto>> FindByNameOrDescription(string texto)
        {
            return await _context.Productos
            .Where(p => p.Nombre.Contains(texto) || p.Descripcion.Contains(texto))
            .ToListAsync();
        }

        public async Task<ICollection<Producto>> FindByPriceRange(decimal min, decimal max)
        {
            return await _context.Productos
            .Where(p => p.Precio >= min && p.Precio <= max)
            .ToListAsync();
        }

        public async Task<ICollection<Producto>> FindByType(string tipo)
        {
            return await _context.Productos
            .Where(p => p.GetType().Name == tipo)
            .ToListAsync();
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return false;

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Producto obj)
        {
            var producto = await _context.Productos.FindAsync(obj.Guid);
            if (producto == null) return false;

            producto.Nombre = obj.Nombre;
            producto.Descripcion = obj.Descripcion;
            producto.Precio = obj.Precio;
            producto.Stock = obj.Stock;
            producto.Categorias = obj.Categorias;

            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
