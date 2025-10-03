using store.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.IRepositorios
{
    public interface IRepositorioPrecompras: IRepositorio<Precompra, int>
    {
        //Async methods
        Precompra FindByCliente(Guid clienteGuid);

        bool Clear(Guid clienteGuid);

        int AddArticulo(Articulo art);

        bool RemoveArticulo(int articuloId);
}
