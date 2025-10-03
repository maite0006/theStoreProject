using store.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace store.LogicaNegocio.IRepositorios
{
    public interface IRepositorioProductos: IRepositorio<Producto, Guid>
    {
        //Async methods
       Task<ICollection<Producto>> FindByCategoria(string categoria);

        Task<ICollection<Producto>> FindByPriceRange(decimal min, decimal max);

        Task<ICollection<Producto>> FindByNameOrDescription(string texto);
        Task<ICollection<Producto>> FindByType(string tipo);

        Task<Producto> FindByGuid(Guid guid);

        Task<ICollection<Producto>> FindAvailable();
    }
}
