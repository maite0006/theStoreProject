using Microsoft.EntityFrameworkCore;
using store.LogicaAplicacion.ICU.ICUCompra.ICUPagos;
using store.LogicaDatos;
using store.LogicaNegocio.CustomExceptions;
using store.LogicaNegocio.CustomExceptions.ProdExceptions;
using store.LogicaNegocio.Entidades;
using store.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUCompra.CUPagos
{
    public class CUConfirmarPagoWebhook : ICUConfirmarPagoWebhook
    {
        private readonly IRepositorioCompras _repositorioCompras;
        private readonly IRepositorioPagos _repoPagos;
        private readonly eStoreDBContext _context;
        public CUConfirmarPagoWebhook(IRepositorioCompras repositorioCompras, eStoreDBContext context, IRepositorioPagos repoPagos)
        {
            _repositorioCompras= repositorioCompras;
            _repoPagos = repoPagos;
            _context= context;
        }
      

        public async Task ConfirmarPagoWH(int pagoId)
        {
            var pago = await _repoPagos.FindByIdAsync(pagoId);
            if (pago == null)
                throw new EntityNotFound("Pago", pagoId);

            if (pago.Estado == EstadoPago.Aprobado)
                return; // idempotente

            pago.Confirmar();

            var compra = await _repositorioCompras.FindByIdAsync(pago.CompraId);
            if (compra == null)
                throw new EntityNotFound("Compra", pago.CompraId);

            if (compra.EstadoCompra != Compra.Estado.Pagada)
                compra.MarcarPagada();

            await _context.SaveChangesAsync();
        }
    }
}
