using store.DTOs.DTOs.Compra;
using store.LogicaAplicacion.ICU.ICUCarrito;
using store.LogicaAplicacion.ICU.ICUCompra;
using store.LogicaAplicacion.Mappers;
using store.LogicaDatos.Repositorios;
using store.LogicaNegocio.CustomExceptions;
using store.LogicaNegocio.CustomExceptions.PrecompraException;
using store.LogicaNegocio.Entidades;
using store.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUCarrito
{
    public class CUCerrarPrecompra : ICUCerrarPrecompra
    {
        private readonly IRepositorioPrecompras _repositorioPrecompras;
        private readonly IRepositorioCompras _repositorioCompras;
        
        public  CUCerrarPrecompra(IRepositorioPrecompras repositorio, IRepositorioCompras repositorioCompras)
        {
            _repositorioPrecompras = repositorio;
            _repositorioCompras=repositorioCompras;
            
        }
        public async Task<CompraDTO> CerrarPrecompra(int precompraId)
        {
            
            Precompra precompra = await _repositorioPrecompras.FindByIdAsync(precompraId);
            if (precompra == null || precompra.Articulos.Count == 0)
                throw new EntityNotFound("Precompra", precompraId);

            var articulosValidos = precompra.Articulos
                .Where(a => a.Producto.Activo && a.Cantidad <= a.Producto.Stock)
                .ToList();

            if (!articulosValidos.Any())
                throw new SinArticulosDisponibles("No hay artículos disponibles para la compra.");

            var compra = new Compra
            {
                ClienteId = precompra.ClienteId,
                Articulos = articulosValidos,
                Total = precompra.CalcularTotal(),
                Fecha = DateTime.Now,
           
            };

            await _repositorioCompras.AddAsync(compra);
            precompra.Articulos.Clear();
            await _repositorioPrecompras.UpdateAsync(precompra);

            return CompraMapper.FromCompra(compra);
        }
    }
}
