using store.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.IRepositorios
{
    public interface IRepositorioPrecompras : IRepositorio<Precompra, int>
    {
        //Async methods
        Task<Precompra> FindByCliente(Guid clienteGuid);

        Task AddArticulo(Articulo art);

        Task<bool> RemoveArticulo(int articuloId);
        Task<ICollection<Articulo>> GetArticulos(Guid clienteGuid);
    }
}
