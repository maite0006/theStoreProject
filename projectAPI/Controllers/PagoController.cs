using Microsoft.AspNetCore.Mvc;
using store.LogicaAplicacion.ICU.ICUCompra.ICUPagos;

namespace projectAPI.Controllers
{
    [ApiController]
    [Route("api/pagos")]
    public class PagosController : ControllerBase
    {
        private readonly ICUConfirmarPago _confirmarPago;

        public PagosController(ICUConfirmarPago confirmarPago)
        {
            _confirmarPago = confirmarPago;
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
    }
}
