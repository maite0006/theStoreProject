using store.LogicaAplicacion.ICU.ICUUsuarios;
using store.LogicaDatos;
using store.LogicaNegocio.CustomExceptions;
using store.LogicaNegocio.CustomExceptions.ProdExceptions;
using store.LogicaNegocio.Entidades;
using store.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUUsuarios
{
    public class CUAgregarFavorito : ICUAgregarFavorito
    {
        private readonly IRepositorioProductos _repositorioProductos;
        private readonly IRepositorioUsuarios _repositorioUsuarios;
        private readonly eStoreDBContext _context;
        public CUAgregarFavorito(IRepositorioProductos repoprods, IRepositorioUsuarios repositorioUsuarios, eStoreDBContext context)
        {
            _repositorioProductos= repoprods;
            _repositorioUsuarios= repositorioUsuarios;
            _context= context;
        }
        public async Task<bool> AgregarProductoFavorito(int userId,Guid prodGuid)
        {
            Producto fav=await _repositorioProductos.FindByGuid(prodGuid);
            Usuario user = await _repositorioUsuarios.FindByIdAsync(userId);
            Cliente cliente = user as Cliente;
            if (user == null)
                throw new EntityNotFound("Cliente", userId);

            if (user is not Cliente cli)
                throw new InvalidOperationException("Solo los clientes pueden tener favoritos.");

            if (fav == null) 
                throw new EntityNotFound("Producto", prodGuid);
          

            if (cliente.ProductosFavoritos.Any(f => f.Id == fav.Id))
                throw new ProductoEnFavoritos("Este producto ya ha sido agregado a sus Favoritos");



            cliente.AgregarProductoFavorito(fav);
            _context.SaveChanges();
            return true;

        }
    }
}
