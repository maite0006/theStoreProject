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
    public class CUConfirmarPago : ICUConfirmarPago
    {
        private readonly IRepositorioCompras _repositorioCompras;
        private readonly eStoreDBContext _context;
        public CUConfirmarPago(IRepositorioCompras repositorioCompras, eStoreDBContext context)
        {
            _repositorioCompras= repositorioCompras;
            _context= context;
        }
        public async Task ConfirmarPago(int pagoId)
        {
            Pago pago = await _repoPagos.FindByIdAsync(pagoId);

            if (pago == null)
                throw new EntityNotFound("Pago", pagoId);

            pago.Confirmar();

            Compra compra = await _repoCompras.FindByIdAsync(pago.CompraId);

            compra.MarcarPagada();

            await _dbContext.SaveChangesAsync();
        }

        public  bool SimulacionMP(Pago p)
        {
            return p!= null;
        }
    }
}
