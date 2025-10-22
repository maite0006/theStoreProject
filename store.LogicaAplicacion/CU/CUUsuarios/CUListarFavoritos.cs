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
        public async Task<ICollection<ProdDTO>> ListarFavoritos(int userID)
        {
            Usuario user=await _repositorioUsuarios.FindByIdAsync(userID);
            Cliente cliente = user as Cliente;
            if (user == null) 
                throw new EntityNotFound("Cliente", userID);
            
            if (user is not Cliente cli)
                throw new InvalidOperationException("Solo los clientes pueden tener favoritos.");

            ICollection<ProdDTO> dtos=new List<ProdDTO>();
            ICollection<Producto> favoritos = cliente.ProductosFavoritos;

            foreach (Producto p in favoritos) { 
                ProdDTO dto= ProdsMapper.fromProdtoDTO(p);
                dtos.Add(dto);
            }
            return dtos;

                
        }
    }
}
