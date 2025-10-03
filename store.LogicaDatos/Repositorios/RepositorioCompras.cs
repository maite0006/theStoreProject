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
        public int AddAsync(Compra nuevo)
        {
            throw new NotImplementedException();
        }

        public List<Compra> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<Compra> FindByCliente(Guid clienteGuid)
        {
            throw new NotImplementedException();
        }

        public ICollection<Compra> FindByDateRange(DateTime inicio, DateTime fin)
        {
            throw new NotImplementedException();
        }

        public Compra FindByGuid(Guid compraGuid)
        {
            throw new NotImplementedException();
        }

        public Compra FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Compra> FindPending()
        {
            throw new NotImplementedException();
        }

        public void RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public int UpdateAsync(Compra obj)
        {
            throw new NotImplementedException();
        }
    }
}
