using store.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static store.LogicaNegocio.Entidades.Compra;

namespace store.LogicaNegocio.IRepositorios
{
    public interface IRepositorioCompras: IRepositorio<Compra, Guid>
    {
        //Async methods
        Task<ICollection<Compra>> FindByCliente(Guid clienteGuid);

        Task<Compra> FindByGuid(Guid compraGuid);

        Task<ICollection<Compra>> FindPending();

        Task<ICollection<Compra>> FindByDateRange(DateTime inicio, DateTime fin);
    }
}
