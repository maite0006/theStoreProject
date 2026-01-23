using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using store.DTOs.DTOs.Articulo;
using store.DTOs.DTOs.Carrito;
using store.DTOs.DTOs.Compra;
using store.LogicaAplicacion.CU.CUCarrito;
using store.LogicaAplicacion.ICU.ICUCarrito;
using store.LogicaNegocio.CustomExceptions;
using store.LogicaNegocio.CustomExceptions.ArticuloExceptions;
using store.LogicaNegocio.CustomExceptions.PrecompraException;
using System.Security.Claims;

namespace projectAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize]
    public class PrecompraController : Controller
    {
        private readonly ICUOperarArticuloCarrito _cuOperarArticuloCarrito;
        private readonly ICUCerrarPrecompra _cuCerrarPrecompra;
        private readonly ICUVerCarrito _cuVerCarrito;
        private readonly ICUVaciarCarrito _cuVaciarCarrito;

        public PrecompraController(store.LogicaAplicacion.ICU.ICUCarrito.ICUOperarArticuloCarrito cuOperarArticuloCarrito, ICUCerrarPrecompra cuCerrarPrecompra, ICUVerCarrito cuVerCarrito, ICUVaciarCarrito cuVaciarCarrito)
        {
            _cuOperarArticuloCarrito = cuOperarArticuloCarrito;
            _cuCerrarPrecompra = cuCerrarPrecompra;
            _cuVerCarrito = cuVerCarrito;
            _cuVaciarCarrito = cuVaciarCarrito;
        }

        [HttpPost("Articulo")]
        [Authorize(Roles = "Cliente")]
        public async Task<IActionResult> OperarArticuloCarrito(ArtDTO art)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                 await _cuOperarArticuloCarrito.Ejecutar(art);

                return Ok("Operación realizada correctamente.");
                
            }
            catch (EntityNotFound ex) 
            {
                return NotFound(ex.Message);
            }
            catch (ErrorFlujoArticulo ex) 
            {
                return BadRequest(ex.Message);
            }
            catch (CantidadArticuloInvalida ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        [HttpGet]
        public async Task<IActionResult> VerCarrito()
        {
            

            var idS = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int id = Convert.ToInt32(idS);
            if (id == null)
            {
                return Unauthorized("No se pudo obtener el ID del usuario autenticado.");
            }
            try
            {

                CarritoDTO carrito = await _cuVerCarrito.VerCarrito(id);
                return Ok(carrito);
            }
            catch (EntityNotFound ex)
            {

                return BadRequest(ex.Message);
            }
            catch (Exception ex) {

                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        [HttpDelete("vaciar")]
        public async Task<IActionResult> VaciarCarrito()
        {
            var idS = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int id = Convert.ToInt32(idS);
            if (id == null)
            {
                return Unauthorized("No se pudo obtener el ID del usuario autenticado.");
            }
            try
            {

                await _cuVaciarCarrito.Vaciar(id);

                return Ok("Carrito vaciado correctamente");
            }
            catch (EntityNotFound ex)
            {
                return NotFound(ex.Message);
            }
            catch (ErrorFlujoArticulo ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del sistema");
            }
        }

        [HttpPost("Cerrar")]
        public async Task<IActionResult> cerrarPrecompra(int precompraId)
        {
            
            if (precompraId < 0)
                return BadRequest("El id de precompra es invalido");
            try
            {
                CompraDTO compra = await _cuCerrarPrecompra.CerrarPrecompra(precompraId);
                return Ok(compra);
            }
            catch (EntityNotFound ex)
            {

                return BadRequest(ex.Message);
            }
            catch(SinArticulosDisponibles ex)
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
