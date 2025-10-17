using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.IRepositorios
{
    public interface IRepositorio<T, TId> where T : class
    {
        Task<int> AddAsync(T nuevo);

        Task<T> FindByIdAsync(int id);

        Task<bool> RemoveAsync(int id);

        Task<List<T>> FindAllAsync();

        Task<bool> UpdateAsync(T obj);

    }
}
