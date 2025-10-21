using store.LogicaAplicacion.ICU.ICUUsuarios;
using store.LogicaNegocio.CustomExceptions;
using store.LogicaNegocio.Entidades;
using store.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUUsuarios
{
    public class CUAgregarFavorito : ICUAgregarFavorito
    {
        private readonly IRepositorioProductos _repositorioProductos;
        private readonly IRepositorioUsuarios _repositorioUsuarios;
        public CUAgregarFavorito(IRepositorioProductos repoprods, IRepositorioUsuarios repositorioUsuarios)
        {
            _repositorioProductos= repoprods;
            _repositorioUsuarios= repositorioUsuarios;
        }
        public async Task<bool> AgregarProductoFavorito(Guid prodGuid)
        {
            //Producto fav=await _repositorioProductos.FindByGuid(prodGuid);
            //if (fav == null) {
             //   throw new EntityNotFound("Producto", prodGuid);
            //}
            //if(fav)
            throw new NotImplementedException()
        }
    }
}
