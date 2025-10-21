using store.DTOs.DTOs.Producto;
using store.LogicaAplicacion.ICU.ICUCategory;
using store.LogicaAplicacion.ICU.ICUUsuarios;
using store.LogicaAplicacion.Mappers;
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
    public class CUListarFavoritos : ICUListarFavoritos
    {
        private readonly IRepositorioUsuarios _repositorioUsuarios;
        public CUListarFavoritos(IRepositorioUsuarios repositorioUsuarios) {
            _repositorioUsuarios=repositorioUsuarios;
        }
        public async Task<List<ProdDTO>> ListarFavoritos(Guid userGUID)
        {
            Usuario user=await _repositorioUsuarios.FindByGuid(userGUID);
            List<ProdDTO> dtos=new List<ProdDTO>();
            Cliente cliente = user as Cliente;
            if (user == null) {
                throw new EntityNotFound("Cliente", userGUID);
            }
            ICollection<Producto> favoritos = cliente.ProductosFavoritos;
            foreach (Producto p in favoritos) { 
                ProdDTO dto= ProdsMapper.fromProdtoDTO(p);
                dtos.Add(dto);
            }
            return dtos;

                
        }
    }
}
