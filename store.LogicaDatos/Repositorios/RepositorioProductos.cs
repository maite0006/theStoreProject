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
        public int AddAsync(Producto nuevo)
        {
            throw new NotImplementedException();
        }

        public List<Producto> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<Producto> FindAvailable()
        {
            throw new NotImplementedException();
        }

        public ICollection<Producto> FindByCategoria(string categoria)
        {
            throw new NotImplementedException();
        }

        public Producto FindByGuid(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Producto FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Producto> FindByNameOrDescription(string texto)
        {
            throw new NotImplementedException();
        }

        public ICollection<Producto> FindByPriceRange(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }

        public ICollection<Producto> FindByType(string tipo)
        {
            throw new NotImplementedException();
        }

        public void RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public int UpdateAsync(Producto obj)
        {
            throw new NotImplementedException();
        }
    }
}
