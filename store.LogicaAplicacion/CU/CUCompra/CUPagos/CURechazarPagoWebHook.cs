using Microsoft.EntityFrameworkCore;
using store.LogicaAplicacion.ICU.ICUCompra.ICUPagos;
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
    public class CURechazarPagoWebHook: ICURechazarPagoWebHook
    {
        private readonly IRepositorioPagos _repoPagos;
        private readonly eStoreDBContext _context;
        public CURechazarPagoWebHook(eStoreDBContext context, IRepositorioPagos repoPagos)
        {
            _repoPagos = repoPagos;
            _context = context;
        }
        public async Task RechazarPagoWH(int pagoId)
        {
            var pago = await _repoPagos.FindByIdAsync(pagoId);
            if (pago == null)
                throw new EntityNotFound("Pago", pagoId);

            if (pago.Estado == EstadoPago.Rechazado)
                return; // idempotente

            pago.Rechazar();

            await _context.SaveChangesAsync();
        }
    }
}
