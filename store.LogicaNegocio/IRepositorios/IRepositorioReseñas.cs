using store.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.IRepositorios
{
    public interface IRepositorioReseñas: IRepositorio<Reseña, int>
    {
        //Async methods
        Task<ICollection<Reseña>> FindByCliente(int clienteid);

        Task<ICollection<Reseña>> FindByProducto(int productoid);

        Task<ICollection<Reseña>> FindByRating(int min, int max);
    }
}
