using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using store.DTOs.DTOs.Articulo;
using store.LogicaAplicacion.CU.CUCarrito;
using store.LogicaAplicacion.ICU.ICUCarrito;
using store.LogicaNegocio.CustomExceptions;
using store.LogicaNegocio.CustomExceptions.ArticuloExceptions;

namespace projectAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize]
    public class PrecompraController : Controller
    {
        private readonly ICUAgregaralCarrito _cuAgregaralCarrito;
        private readonly ICUCalcularTotal _cuCalcularTotal;
        private readonly ICUCerrarPrecompra _cuCerrarPrecompra;
        private readonly ICUVerCarrito _cuVerCarrito;

        public PrecompraController(ICUAgregaralCarrito cuAgregaralCarrito, ICUCalcularTotal cuCalcularTotal, ICUCerrarPrecompra cuCerrarPrecompra, ICUVerCarrito cuVerCarrito)
        {
            _cuAgregaralCarrito = cuAgregaralCarrito;
            _cuCalcularTotal = cuCalcularTotal;
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

    }
}
