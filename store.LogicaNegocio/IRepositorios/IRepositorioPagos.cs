using store.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.IRepositorios
{
        
    public interface IRepositorioPagos : IRepositorio<Pago, int>
    {
        Task<List<Pago>> GetByCompraIdAsync(int compraId);
    }
}
