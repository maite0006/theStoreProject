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
        public int AddAsync(Reseña nuevo)
        {
            throw new NotImplementedException();
        }

        public List<Reseña> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<Reseña> FindByCliente(Guid clienteGuid)
        {
            throw new NotImplementedException();
        }

        public Reseña FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Reseña> FindByProducto(Guid productoGuid)
        {
            throw new NotImplementedException();
        }

        public ICollection<Reseña> FindByRating(int min, int max)
        {
            throw new NotImplementedException();
        }

        public void RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdateAsync(Reseña obj)
        {
            throw new NotImplementedException();
        }
    }
}
