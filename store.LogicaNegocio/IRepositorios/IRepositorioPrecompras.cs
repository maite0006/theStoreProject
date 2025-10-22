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
        public Task<int?> ExisteArticuloEnPrecompra(int productoId, int precompraId);
       
        //Async methods
        Task<Precompra> FindByCliente(int clienteid);

        Task AddArticulo(Articulo art);

        Task<bool> RemoveArticulo(int articuloId);
        Task<ICollection<Articulo>> GetArticulos(int clienteid);
    }
}
