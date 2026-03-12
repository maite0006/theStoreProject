using Microsoft.AspNetCore.Mvc;
using store.DTOs.DTOs.Compra;
using store.LogicaAplicacion.CU.CUCompra.CUPagos;
using store.LogicaAplicacion.ICU.ICUCompra.ICUPagos;
using store.LogicaNegocio.CustomExceptions;

namespace projectAPI.Controllers
{
    [ApiController]
    [Route("api/pagos")]
    public class PagosController : ControllerBase
    {
        private readonly ICUConfirmarPago _confirmarPago;
        private readonly ICUCrearPago _crearPago;

        public PagosController(ICUConfirmarPago confirmarPago, ICUCrearPago crearPago)
        {
            _confirmarPago = confirmarPago;
            _crearPago = crearPago;
        }

        [HttpPost("{pagoId}/confirmar")]
        public async Task<IActionResult> ConfirmarPago(int pagoId)
        {
            await _confirmarPago.ConfirmarPago(pagoId);

            return Ok(new
            {
                mensaje = "Pago confirmado"
            });
        }
        [HttpPost("{compraId}/pagos")]
        public async Task<IActionResult> CrearPago(int compraId, [FromBody] PagoDTO dto)
        {

            try
            {
                var url = await _crearPago.Ejecutar(compraId, dto);

                return Ok(new
                {
                    urlPago = url
                });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (EntityNotFound ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    
      [HttpPost("webhook")]
        public async Task<IActionResult> Webhook([FromBody] dynamic notification)
        {
            var paymentId = notification?.data?.id;

            if (paymentId == null)
                return BadRequest();

            // luego consultarías el pago a MercadoPago
            // y ejecutarías ConfirmarPago

            return Ok();
        }
    }
}
