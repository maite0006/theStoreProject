using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using store.DTOs.Pago;
using store.LogicaAplicacion.CU.CUCompra.CUPagos;
using store.LogicaAplicacion.ICU.ICUCompra.ICUPagos;
using store.LogicaNegocio.CustomExceptions;
using System.Security.Claims;

namespace projectAPI.Controllers
{
    [ApiController]
    [Route("api/pagos")]
    [Authorize(Roles = "Cliente")]
    public class PagosController : ControllerBase
    {
        private readonly ICUConfirmarPagoWebhook _confirmarPago;
        private readonly ICUCrearPago _crearPago;

        public PagosController(ICUConfirmarPagoWebhook confirmarPago, ICUCrearPago crearPago)
        {
            _confirmarPago = confirmarPago;
            _crearPago = crearPago;
        }
        private int GetUserId()
        {
            var idS = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(idS))
                throw new UnauthorizedAccessException("Debe autenticarse.");

            return Convert.ToInt32(idS);
        }

        [HttpPost("{pagoId}/confirmar")]
        public async Task<IActionResult> ConfirmarPago(int pagoId)
        {

            try
            {
                int userId = GetUserId();
                await _confirmarPago.ConfirmarPagoWH(pagoId);

                return Ok(new { mensaje = "Pago confirmado" });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid();
            }
            catch (EntityNotFound ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        [HttpPost("{compraId}/pagos")]
        public async Task<IActionResult> CrearPago(int compraId, [FromBody] CrearPagoDTO dto)
        {

            try
            {
                int userId = GetUserId();
                var url = await _crearPago.Ejecutar(compraId, dto,userId);

                return Ok(new
                {
                    urlPago = url
                });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid();
            }
            catch (EntityNotFound ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    
     
    }
}
