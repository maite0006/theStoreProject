using MercadoPago.Client.Payment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using store.DTOs.DTOs.WebHook;
using store.LogicaAplicacion.ICU.ICUCompra.ICUPagos;
using store.LogicaNegocio.Entidades;
using System.Security.Claims;

namespace projectAPI.Controllers
{
    [ApiController]
    [Route("api/mercadopago/webhook")]
   
    public class MercadoPagoWebhookController : ControllerBase
    {
        private readonly ICUConfirmarPagoWebhook _cuConfirmarPago;
        private readonly ICURechazarPagoWebHook _cuRechazarPago;

        public MercadoPagoWebhookController(ICUConfirmarPagoWebhook cuConfirmarPago, ICURechazarPagoWebHook cuRechazarPago)
        {
            _cuConfirmarPago = cuConfirmarPago;
            _cuRechazarPago = cuRechazarPago;
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Webhook([FromBody] WebhookDTO body)
        {

            if (body?.Type?.ToLower() != "payment" || body.Data == null || string.IsNullOrWhiteSpace(body.Data.Id))// Se retorna OK para evitar reintentos innecesarios si el payload no es el esperado
                return Ok();
            try
            {
                var client = new PaymentClient();
                var payment = await client.GetAsync(long.Parse(body.Data.Id));

                if (!int.TryParse(payment.ExternalReference, out var pagoId))
                    return Ok();

                switch (payment.Status)
                {
                    case "approved":
                        await _cuConfirmarPago.ConfirmarPagoWH(pagoId);
                        break;

                    case "rejected":
                    case "cancelled":
                        await _cuRechazarPago.RechazarPagoWH(pagoId);
                        break;

                    default:
                        // pending / in_process -> no hacer nada
                        break;
                }
                Console.WriteLine("WEBHOOK RECIBIDO");
                Console.WriteLine($"PaymentId: {body?.Data?.Id}");
                return Ok();

            }
            catch 
            {
                return NotFound();
            }
        }
    }

}
