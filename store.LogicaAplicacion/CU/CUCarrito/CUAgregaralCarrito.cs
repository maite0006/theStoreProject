using Microsoft.EntityFrameworkCore;
using store.DTOs.DTOs.Articulo;
using store.DTOs.DTOs.Producto;
using store.LogicaAplicacion.ICU.ICUArticulos;
using store.LogicaAplicacion.ICU.ICUCarrito;
using store.LogicaDatos;
using store.LogicaNegocio.CustomExceptions;
using store.LogicaNegocio.CustomExceptions.ArticuloExceptions;
using store.LogicaNegocio.Entidades;
using store.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUCarrito
{
    public class CUAgregaralCarrito : ICUAgregaralCarrito
    {
        private readonly IRepositorioPrecompras _repositorioPrecompras;
        private readonly ICUEditarCantArt _cuEditarCantArt;
        private readonly ICUAltaArticulo _cuAltaArticulo;
        private readonly eStoreDBContext _context;

        public CUAgregaralCarrito(IRepositorioPrecompras repositorioPrecompras, ICUEditarCantArt cUEditarCantArt, ICUAltaArticulo cUAltaArticulo, eStoreDBContext store)
        {
            _repositorioPrecompras = repositorioPrecompras;
            _cuEditarCantArt = cUEditarCantArt;
            _cuAltaArticulo = cUAltaArticulo;
            _context = store;
        }
        public async Task<bool> AgregarAlCarrito(ArtDTO dto)
        {
            Producto producto = await _context.Productos.FirstOrDefaultAsync(p => p.Id == dto.productoId);
            if (producto == null)
                throw new EntityNotFound("Producto", dto.productoId);

            if (!producto.Activo)
                throw new ErrorFlujoArticulo("El producto no está disponible para la venta.");

            if (dto.cantidad > producto.Stock)
                throw new CantidadArticuloInvalida("No hay stock suficiente para la cantidad solicitada.");
            //Articulo articulo= Mappers.ArticuloMapper.FromDTO(dto);
            int precompraId = dto.precompraId ?? throw new ArgumentException("El ArtDTO debe tener un precompraId válido para agregar al carrito.");
            int? existe= await _repositorioPrecompras.ExisteArticuloEnPrecompra(dto.productoId, precompraId);

            if (existe!=null)
            {
                int id = (int)existe;
                return await _cuEditarCantArt.EditarCantidadArticulo( id, dto.cantidad);  
            }
            else
            {
                int id= await _cuAltaArticulo.AltaArticulo(dto);
                return id!=0;
            }
        }
    }
}
