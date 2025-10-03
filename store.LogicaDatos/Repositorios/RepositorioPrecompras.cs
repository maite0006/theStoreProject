using store.LogicaNegocio.Entidades;
using store.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaDatos.Repositorios
{
    public class RepositorioPrecompras : IRepositorioPrecompras
    {
        public bool AddArticulo(Articulo art)
        {
            throw new NotImplementedException();
        }

        public int AddAsync(Precompra nuevo)
        {
            throw new NotImplementedException();
        }

        public bool Clear(Guid clienteGuid)
        {
            throw new NotImplementedException();
        }

        public List<Precompra> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Precompra FindByCliente(Guid clienteGuid)
        {
            throw new NotImplementedException();
        }

        public Precompra FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveArticulo(int articuloId)
        {
            throw new NotImplementedException();
        }

        public void RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdateAsync(Precompra obj)
        {
            throw new NotImplementedException();
        }

        int IRepositorioPrecompras.AddArticulo(Articulo art)
        {
            throw new NotImplementedException();
        }
    }
}
