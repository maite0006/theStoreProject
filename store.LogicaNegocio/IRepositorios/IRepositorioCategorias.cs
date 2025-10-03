using store.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace store.LogicaNegocio.IRepositorios
{
    public interface IRepositorioCategorias: IRepositorio<Category, int>
    {
        //Async methods
        Task<Category> FindByName(string nombre);
        Task<ICollection<Category>> FindByProducto(Guid productoGuid);
    }
}
