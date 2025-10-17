using store.DTOs.DTOs.Producto;
using store.LogicaAplicacion.ICU.ICUProductos;
using store.LogicaNegocio.Entidades;
using store.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUProductos
{
    public class CUObtenerProd : ICUObtenerProd
    {
        private readonly IRepositorioProductos _repositorioProductos;
        public CUObtenerProd(IRepositorioProductos repositorioProductos)
        {
            _repositorioProductos = repositorioProductos;
        }

        public async Task<ProdDTO> ObtenerProdbyID(int id)
        {
            Producto p = await _repositorioProductos.FindByIdAsync(id);
            ProdDTO dto= Mappers.ProdsMapper.fromProdtoDTO(p);
            return dto;
        }
    }
}
