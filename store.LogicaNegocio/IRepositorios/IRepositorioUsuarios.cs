using store.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.IRepositorios
{
    public interface IRepositorioUsuarios:IRepositorio<Usuario, Guid>
    {
        //Async methods
        Task<Usuario> FindByEmail(string email);
        Task<Usuario> FindByNombre (string nombre);


    }
}
