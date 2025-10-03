using store.LogicaNegocio.Entidades;
using store.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaDatos.Repositorios
{
    public class RepositoioCategorias : IRepositorioCategorias
    {
        public int AddAsync(Category nuevo)
        {
            throw new NotImplementedException();
        }

        public List<Category> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Category FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Category FindByName(string nombre)
        {
            throw new NotImplementedException();
        }

        public ICollection<Category> FindByProducto(Guid productoGuid)
        {
            throw new NotImplementedException();
        }

        public void RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdateAsync(Category obj)
        {
            throw new NotImplementedException();
        }
    }
}
