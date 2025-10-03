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
        ICollection<Producto> FindByCategoria(string categoria);

        ICollection<Producto> FindByPriceRange(decimal min, decimal max);

        ICollection<Producto> FindByNameOrDescription(string texto);
        ICollection<Producto> FindByType(string tipo);

        Producto FindByGuid(Guid guid);

        ICollection<Producto> FindAvailable();
    }
}
