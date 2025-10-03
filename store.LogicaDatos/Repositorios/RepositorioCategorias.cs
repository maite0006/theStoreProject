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
            await _context.Categories.AddAsync(nuevo);
            return nuevo.Id; 
        }

        public Task<List<Category>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> FindByName(string nombre)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Category>> FindByProducto(Guid productoGuid)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Category obj)
        {
            throw new NotImplementedException();
        }
    }
}
