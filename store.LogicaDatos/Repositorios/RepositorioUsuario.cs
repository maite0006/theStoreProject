using store.LogicaNegocio.Entidades;
using store.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaDatos.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuarios
    {
        public int AddAsync(Usuario nuevo)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Usuario FindByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Usuario FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Usuario FindByNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public void RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public int UpdateAsync(Usuario obj)
        {
            throw new NotImplementedException();
        }
    }
}
