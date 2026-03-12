using Microsoft.EntityFrameworkCore;
using store.DTOs.DTOs.Compra;
using store.LogicaAplicacion.ICU.ICUCompra.ICUPagos;
using store.LogicaAplicacion.Mappers;
using store.LogicaDatos;
using store.LogicaNegocio.CustomExceptions;
using store.LogicaNegocio.Entidades;
using store.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUCompra.CUPagos
{
    public class CUCrearPago:ICUCrearPago
    {
        private readonly IRepositorioCompras _repositorioCompras;
        private readonly eStoreDBContext _context;

        public CUCrearPago(IRepositorioCompras repositorioCompras, eStoreDBContext context) {
            _repositorioCompras=repositorioCompras;
            _context=context;
        }
        public async Task<int> Ejecutar(int compraId, PagoDTO dto)
        {
            Compra compra = await _repositorioCompras.FindByIdAsync(compraId);

            if (compra == null)
                throw new EntityNotFound("Compra", compraId);

            if (compra.EstadoCompra != Compra.Estado.Pendiente)
                throw new InvalidOperationException("La compra no admite pagos");

            Pago pago = PagoMapper.FromDTO(dto);

            pago.CompraId = compraId;

            compra.Pagos.Add(pago);

            _context.Pagos.Add(pago);

            await _context.SaveChangesAsync();

            return pago.Id;

        }
    }
}
