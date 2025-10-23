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
        private readonly ICUAgregaralCarrito _cuAgregaralCarrito;
        private readonly ICUCerrarPrecompra _cuCerrarPrecompra;
        private readonly ICUVerCarrito _cuVerCarrito;

        public PrecompraController(ICUAgregaralCarrito cuAgregaralCarrito, ICUCerrarPrecompra cuCerrarPrecompra, ICUVerCarrito cuVerCarrito)
        {
            _cuAgregaralCarrito = cuAgregaralCarrito;
            _cuCerrarPrecompra = cuCerrarPrecompra;
            _cuVerCarrito = cuVerCarrito;
        }

        [HttpPost("Agregar")]
        [Authorize(Roles = "Cliente")]
        public async Task<IActionResult> AgregaralCarrito(ArtDTO art)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                bool agregado = await _cuAgregaralCarrito.AgregarAlCarrito(art);

                if (agregado)
                    return Ok("Artículo agregado o actualizado en el carrito correctamente." );
                else
                    return StatusCode(500,  "No se pudo agregar el artículo al carrito." );
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
