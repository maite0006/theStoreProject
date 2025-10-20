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
            .Include(c => c.Pago)
            .Include(c => c.Envio)
            .ToListAsync();
        }

        public async Task<List<Compra>> FindByCliente(int clienteid)
        {
            return await _context.Compras
            .Include(c => c.Articulos)
            .Include(c => c.Cliente)
            .Include(c => c.Pago)
            .Include(c => c.Envio)
            .Where(c => c.Cliente.Id == clienteid)
            .ToListAsync();
        }

        public async Task<List<Compra>> FindByDateRange(DateTime inicio, DateTime fin)
        {
            return await _context.Compras
            .Include(c => c.Articulos)
            .Include(c => c.Cliente)
            .Include(c => c.Pago)
            .Include(c => c.Envio)
            .Where(c => c.Fecha >= inicio && c.Fecha <= fin)
            .ToListAsync();
        }

        public async Task<Compra> FindByGuid(Guid compraGuid)
        {
            return await _context.Compras
            .Include(c => c.Articulos)
            .Include(c => c.Cliente)
            .Include(c => c.Pago)
            .Include(c => c.Envio)
            .FirstOrDefaultAsync(c => c.Guid == compraGuid);
        }

        public async Task<Compra> FindByIdAsync(int id)
        {
            return await _context.Compras
            .Include(c => c.Articulos)
            .Include(c => c.Cliente)
            .Include(c => c.Pago)
            .Include(c => c.Envio)
            .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Compra>> FindByEstado(string estado)
        {
            return await _context.Compras
            .Include(c => c.Articulos)
            .Include(c => c.Cliente)
            .Include(c => c.Pago)
            .Include(c => c.Envio)
            .Where(c => c.EstadoCompra.ToString() == estado)
            .ToListAsync();
        }

        public async Task<bool> RemoveAsync(int Id)
        {
            var compra = await _context.Compras.FindAsync(Id);
            if (compra == null) return false;

            _context.Compras.Remove(compra);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Compra obj)
        {
            _context.Compras.Update(obj);
            int cambios = await _context.SaveChangesAsync();
            return cambios > 0;
        }
        public async Task<List<Compra>> FindPending()
        {
            return await _context.Compras
            .Include(c => c.Articulos)
            .Include(c => c.Cliente)
            .Where(c => c.EstadoCompra == Compra.Estado.Pendiente)
            .ToListAsync();
        }


    }
}
