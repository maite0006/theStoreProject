using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.IRepositorios
{
    public interface IRepositorio<T, TId> where T : class
    {
        int AddAsync(T nuevo);

        T FindByIdAsync(TId id);

        void RemoveAsync(TId id);

        List<T> FindAllAsync();

        int UpdateAsync(T obj);

    }
}
