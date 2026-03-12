using Microsoft.EntityFrameworkCore;
using store.LogicaNegocio.Entidades;
using store.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static store.LogicaDatos.Repositorios.RepositorioPagos;

namespace store.LogicaDatos.Repositorios
{

    public class RepositorioPagos : IRepositorioPagos
    {
        private readonly eStoreDBContext _context;

        public RepositorioPagos(eStoreDBContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Pago nuevo)
        {
            await _context.Pagos.AddAsync(nuevo);
            await _context.SaveChangesAsync();
            return nuevo.Id;
        }

        public async Task<Pago> FindByIdAsync(int id)
        {
            return await _context.Pagos
                .Include(p => p.Compra)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            Pago pago = await _context.Pagos.FindAsync(id);

            if (pago == null)
                return false;

            _context.Pagos.Remove(pago);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Pago>> FindAllAsync()
        {
            return await _context.Pagos.ToListAsync();
        }

        public async Task<bool> UpdateAsync(Pago obj)
        {
            _context.Pagos.Update(obj);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Pago>> GetByCompraIdAsync(int compraId)
        {
            return await _context.Pagos
                .Where(p => p.CompraId == compraId)
                .ToListAsync();
        }
    }
