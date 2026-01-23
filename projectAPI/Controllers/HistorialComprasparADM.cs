using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using store.LogicaAplicacion.ICU.ICUCompra;

namespace projectAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Adm")]
    public class HistorialComprasparADM : Controller
    {
       
            private readonly ICUHistorialGeneralCompras _cuHistorial;

            public HistorialComprasparADM(ICUHistorialGeneralCompras cuHistorial)
            {
                _cuHistorial = cuHistorial;
            }

            
            [HttpGet]
            public async Task<IActionResult> HistorialGeneral()
            {
                try
                {
                    var compras = await _cuHistorial.HistorialGeneral();
                    return Ok(compras);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            
            [HttpGet("pendientes")]
            public async Task<IActionResult> HistorialPendientes()
            {
                try
                {
                    var compras = await _cuHistorial.HistorialComprasPending();
                    return Ok(compras);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            
            [HttpGet("estado")]
            public async Task<IActionResult> HistorialPorEstado([FromQuery] string estado)
            {
                if (string.IsNullOrWhiteSpace(estado))
                    return BadRequest("El estado es obligatorio.");

                try
                {
                    var compras = await _cuHistorial.HistorialComprasbyEstadoEnvio(estado);
                    return Ok(compras);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }

            
            [HttpGet("fechas")]
            public async Task<IActionResult> HistorialPorFechas(
                [FromQuery] DateTime min,
                [FromQuery] DateTime max)
            {
                if (min > max)
                    return BadRequest("La fecha mínima no puede ser mayor a la máxima.");

                try
                {
                    var compras = await _cuHistorial.HistorialComprasbyFecha(min, max);
                    return Ok(compras);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error interno del servidor: {ex.Message}");
                }
            }
        }

    }
}
