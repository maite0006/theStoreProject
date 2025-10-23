using store.DTOs.DTOs.Articulo;
using store.DTOs.DTOs.Carrito;
using store.LogicaAplicacion.ICU.ICUCarrito;
using store.LogicaNegocio.CustomExceptions;
using store.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUCarrito
{
    public class CUVerCarrito : ICUVerCarrito
    {
        private readonly IRepositorioPrecompras _repositorio;

        public CUVerCarrito(IRepositorioPrecompras repositorio)
        {
            _repositorio = repositorio;
        }
        public async Task<CarritoDTO> VerCarrito(int usuarioId)
        {
            var precompra = await _repositorio.FindByCliente(usuarioId);

            if (precompra == null)
                throw new EntityNotFound("Precompra");

            var carritoDto = new CarritoDTO
            {
                 PrecompraId= precompra.Id,
                Total =  precompra.CalcularTotal(),
            };

            foreach (var art in precompra.Articulos)
            {
                ArticuloCarritoDTO dto= Mappers.ArticuloMapper.FromArticulo(art);
                carritoDto.Articulos.Add(dto);
            }

            return carritoDto;
        }
    }
    
}
