using store.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static store.LogicaNegocio.Entidades.Compra;

namespace store.LogicaNegocio.IRepositorios
{
    public interface IRepositorioCompras: IRepositorio<Compra, Guid>
    {
        //Async methods
        ICollection<Compra> FindByCliente(Guid clienteGuid);

        Compra FindByGuid(Guid compraGuid);

        ICollection<Compra> FindPending();

        ICollection<Compra> FindByDateRange(DateTime inicio, DateTime fin);
    }
}
