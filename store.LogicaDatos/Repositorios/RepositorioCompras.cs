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
    public class RepositorioCompras : IRepositorioCompras
    {
        private readonly eStoreDBContext _context;

        public RepositorioCompras(eStoreDBContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Compra nuevo)
        {
            await _context.Compras.AddAsync(nuevo);
            await _context.SaveChangesAsync();
            return nuevo.Id;
        }

        public async Task<List<Compra>> FindAllAsync()
        {
            return await _context.Compras
            .Include(c => c.Articulos)
            .Include(c => c.Cliente)
            .ToListAsync();
        }

        public async Task<ICollection<Compra>> FindByCliente(Guid clienteGuid)
        {
            return await _context.Compras
            .Include(c => c.Articulos)
            .Where(c => c.Cliente.Guid == clienteGuid)
            .ToListAsync();
        }

        public async Task<ICollection<Compra>> FindByDateRange(DateTime inicio, DateTime fin)
        {
            return await _context.Compras
            .Include(c => c.Articulos)
            .Where(c => c.Fecha >= inicio && c.Fecha <= fin)
            .ToListAsync();
        }

        public async Task<Compra> FindByGuid(Guid compraGuid)
        {
            return await _context.Compras
            .Include(c => c.Articulos)
            .FirstOrDefaultAsync(c => c.Guid == compraGuid);
        }

        public async Task<Compra> FindByIdAsync(int id)
        {
            return await _context.Compras
            .Include(c => c.Articulos)
            .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ICollection<Compra>> FindByEstado(string estado)
        {
            return await _context.Compras
            .Include(c => c.Articulos)
            .Where(c => c.EstadoCompra.ToString() == estado)
            .ToListAsync();
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var compra = await _context.Compras.FindAsync(id);
            if (compra == null) return false;

            _context.Compras.Remove(compra);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Compra obj)
        {
            return false;
        }
    }
}
