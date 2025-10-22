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

namespace store.LogicaAplicacion.CU.CUCompra
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
        public async Task<bool> ConfirmarPago(int CompraID)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                Compra compra = await _repositorioCompras.FindByIdAsync(CompraID);
                if (compra == null)
                    throw new EntityNotFound("Compra", CompraID);

                if (compra.Pago.Estado != EstadoPago.Pendiente)
                    throw new InvalidOperationException("El pago ya fue procesado.");

                foreach (var art in compra.Articulos)
                {
                    if (art.Producto.Stock < art.Cantidad)
                        throw new StockInsuficiente($"Stock insuficiente para {art.Producto.Nombre}.");

                }
                foreach (var art in compra.Articulos)
                {
                    art.Producto.Stock -= art.Cantidad;
                }
                // Simulación de llamada a MercadoPago
                bool pagoOk = SimulacionMP(compra.Pago);

                if (pagoOk)
                {
                    compra.Pago.Estado = EstadoPago.Aprobado;
                    compra.EstadoCompra = Compra.Estado.Pagada;
                }
                else
                {
                    compra.Pago.Estado = EstadoPago.Rechazado;
                    compra.EstadoCompra = Compra.Estado.Pendiente;
                    foreach (var art in compra.Articulos)
                        art.Producto.Stock += art.Cantidad;

                }
                compra.Fecha=DateTime.Now;
                await _repositorioCompras.UpdateAsync(compra);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return pagoOk;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public  bool SimulacionMP(Pago p)
        {
            return p!= null;
        }
    }
}
