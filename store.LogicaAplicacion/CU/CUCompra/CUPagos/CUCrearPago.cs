using Microsoft.EntityFrameworkCore;
using store.LogicaAplicacion.ICU.ICUCompra.ICUPagos;
using store.LogicaAplicacion.Mappers;
using store.LogicaDatos;
using store.LogicaNegocio.CustomExceptions;
using store.LogicaNegocio.Entidades;
using store.LogicaNegocio.IRepositorios;
using MercadoPago.Client.Preference;
using MercadoPago.Resource.Preference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using store.DTOs.Pago;

namespace store.LogicaAplicacion.CU.CUCompra.CUPagos
{
    public class CUCrearPago:ICUCrearPago
    {
        private readonly IRepositorioCompras _repositorioCompras;
        private readonly eStoreDBContext _context;
        private readonly IRepositorioPagos _repoPagos;
        public CUCrearPago(IRepositorioCompras repositorioCompras, eStoreDBContext context, IRepositorioPagos pagos) {
            _repositorioCompras=repositorioCompras;
            _context=context;
            _repoPagos = pagos;
        }
        public async Task<String> Ejecutar(int compraId, CrearPagoDTO dto, int userId)
        {

            Compra compra = await _repositorioCompras.FindByIdAsync(compraId);
            if (compra == null)
                throw new EntityNotFound("Compra", compraId);

            if (compra.ClienteId != userId)
                throw new UnauthorizedAccessException("Usuario no autorizado para pagar esta compra.");


            if (compra.EstadoCompra != Compra.Estado.Pendiente)
                throw new InvalidOperationException("La compra no admite pagos");
            if (compra.Pagos.Any(p => p.Estado == EstadoPago.Pendiente || p.Estado == EstadoPago.Aprobado))
                throw new InvalidOperationException("La compra ya tiene un pago activo o aprobado");

            Pago pago = PagoMapper.FromDTO(dto);

            pago.CompraId = compraId;
            pago.Monto= compra.Total;

            _context.Pagos.Add(pago);

            await _context.SaveChangesAsync();

            var preferenceRequest = new PreferenceRequest
            {
                Items = new List<PreferenceItemRequest>
            {
                new PreferenceItemRequest
                {
                    Title = "Compra eStore",
                    Quantity = 1,
                    CurrencyId = "UYU",
                    UnitPrice = compra.Total
                }
            },
                ExternalReference = pago.Id.ToString(),
                NotificationUrl = "https://cutest-rachelle-uncaparisoned.ngrok-free.dev/api/mercadopago/webhook"
            };

            var client = new PreferenceClient();
            try
            {
                Preference preference = await client.CreateAsync(preferenceRequest);
                pago.GatewayPaymentId = preference.Id;
                await _context.SaveChangesAsync();
                return preference.InitPoint;
            }
            catch
            {
                pago.Rechazar();
                await _context.SaveChangesAsync();
                throw new InvalidOperationException("No se pudo iniciar el pago.");
            }

        
        }
    }
}
