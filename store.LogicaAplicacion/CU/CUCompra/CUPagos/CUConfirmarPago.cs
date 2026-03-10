using Microsoft.EntityFrameworkCore;
using store.LogicaAplicacion.ICU.ICUCompra;
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
    public class CUConfirmarPago : ICUConfirmarPago
    {
        private readonly IRepositorioCompras _repositorioCompras;
        private readonly eStoreDBContext _context;
        public CUConfirmarPago(IRepositorioCompras repositorioCompras, eStoreDBContext context)
        {
            _repositorioCompras= repositorioCompras;
            _context= context;
        }
        public async Task<bool> ConfirmarPago(int compraId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            Compra compra = await _repositorioCompras.FindByIdAsync(compraId);

            if (compra == null)
                throw new EntityNotFound("Compra", compraId);

            var pago = compra.Pagos
                .FirstOrDefault(p => p.Estado == EstadoPago.Pendiente);

            if (pago == null)
                throw new InvalidOperationException("No hay pagos pendientes.");

            foreach (var art in compra.Articulos)
            {
                if (art.Producto.Stock < art.Cantidad)
                    throw new StockInsuficiente($"Stock insuficiente para {art.Producto.Nombre}");
            }

            foreach (var art in compra.Articulos)
                art.Producto.Stock -= art.Cantidad;

            bool pagoOk = SimulacionMP(pago);

            if (pagoOk)
            {
                pago.Estado = EstadoPago.Aprobado;
                compra.EstadoCompra = Compra.Estado.Pagada;
            }
            else
            {
                pago.Estado = EstadoPago.Rechazado;
                compra.EstadoCompra = Compra.Estado.Pendiente;

                foreach (var art in compra.Articulos)
                    art.Producto.Stock += art.Cantidad;
            }

            compra.Fecha = DateTime.Now;

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return pagoOk;
        }

        public  bool SimulacionMP(Pago p)
        {
            return p!= null;
        }
    }
}
