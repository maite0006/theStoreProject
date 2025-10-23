using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using store.DTOs.DTOs.Producto;
using store.LogicaAplicacion.ICU.ICUProductos;
using store.LogicaNegocio.CustomExceptions;
using store.LogicaNegocio.CustomExceptions.ProdExceptions;
using System.Security.Claims;

namespace projectAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize]
    public class ProductoController : ControllerBase
    {
        private readonly ICUObtenerProd _cUObtenerProd;
        private readonly ICUListarProds _cUListarProds;
        private readonly ICUBajaProd _cUBajaProd;
        private readonly ICUAltaProd _cUAltaProd;

        public ProductoController(ICUAltaProd cuAltaprod, ICUBajaProd cuBajaProd, ICUListarProds cuListarProds, ICUObtenerProd cuObtenerProd)
        {
            _cUAltaProd = cuAltaprod;
            _cUBajaProd = cuBajaProd;
            _cUObtenerProd = cuObtenerProd;
            _cUListarProds = cuListarProds;
        }
        //Falta obtener prod

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> eliminarProd( Guid idProd)
        {
            var idS = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int idAdm = Convert.ToInt32(idS);
            if (idAdm == null)
            {
                return Unauthorized("No se pudo obtener el ID del Administrador autenticado.");
            }
            try
            {
                var eliminado = await _cUBajaProd.EliminarProd(idProd, idAdm);
                if (!eliminado)
                    return BadRequest("Se produjo un error al eliminar su producto");
                return Ok($"Prod {idProd} eliminado con exito");

            }
            catch (EntityNotFound ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }

        }
        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> desactivarProd(Guid id)
        {
            try
            {
                var desactivado = await _cUBajaProd.BajaProductoAsync(id);
                if(!desactivado)
                    return BadRequest("Se produjo un error al dar de baja su producto");

                return Ok($"Prod {id} dado de baja con exito");
            }
            catch (EntityNotFound ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }

        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> AgregarProd([FromBody] AltaProdInDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Los datos ingresados son invalidos");
            var idS = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int idAdm = Convert.ToInt32(idS);
            if (idAdm == null)
            {
                return Unauthorized("No se pudo obtener el ID del Administrador autenticado.");
            }
            try
            {
                AltaProdOutDTO dtoOut = await _cUAltaProd.AgregarP(dto, idAdm);
                return Ok(dtoOut);

            }
            catch (ProdInvalido ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }

        }

        [HttpGet("listar")]
        public async Task<IActionResult> getTodos() {
            try
            {
                var lista = await _cUListarProds.obtenerTodos();
                if (lista == null || lista.Count == 0)
                    return Ok("En el momento no hay productos registrados.");

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error interno del servidor", detalle = ex.Message });
            }
        }
        [HttpGet("Activos")]
        public async Task<IActionResult> getActivos()
        {
            try
            {
                var lista = await _cUListarProds.obtenerActivos();
                if (lista == null || lista.Count == 0)
                    return Ok("No se encontraron productos activos.");
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error interno del servidor", detalle = ex.Message });
            }
        }
        [HttpGet("byTipo")]
        public async Task<IActionResult> getbyTipo([FromQuery] string tipo)
        {
            try
            {
                var lista = await _cUListarProds.obtenerbytype(tipo);
                if (lista == null || lista.Count == 0)
                    return Ok("No se encontraron productos de este tipo.");
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error interno del servidor", detalle = ex.Message });
            }
        }

        [HttpGet("byPrecio")]
        public async Task<IActionResult> getbyPrecio([FromQuery] int min, [FromQuery] int max)
        {
            try
            {
                var lista = await _cUListarProds.obtenerbyPriceRange(min, max);
                if (lista == null || lista.Count == 0)
                    return Ok("No se encontraron productos en este rango de precio.");
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error interno del servidor", detalle = ex.Message });
            }
        }
        [HttpGet("byCategoria")]
        public async Task<IActionResult> getbyCategoria([FromQuery] string cat)
        {
            try
            {
                var lista = await _cUListarProds.obtenerbyCategoria(cat);
                if (lista == null || lista.Count == 0)
                    return Ok("No hay productos registrados en esta categoria.");
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error interno del servidor", detalle = ex.Message });
            }
        }





    }
}
