using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using store.DTOs.DTOs.Categoria;
using store.DTOs.DTOs.Producto;
using store.LogicaAplicacion.CU.CUProductos;
using store.LogicaAplicacion.ICU.ICUCategory;
using store.LogicaAplicacion.ICU.ICUProductos;
using store.LogicaNegocio.CustomExceptions;
using store.LogicaNegocio.CustomExceptions.ProdExceptions;
using store.LogicaNegocio.Entidades;

namespace projectAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICUAltaCategoria _cUAltaCategoria;
        private readonly ICUBajaCategoria _cUBajaCat;
        private readonly ICUListarCategorias _cUListarCategorias;
       

        public CategoryController(ICUAltaCategoria cuAltaCat, ICUBajaCategoria cuBajaCat, ICUListarCategorias cuListarCats)
        {
            _cUAltaCategoria = cuAltaCat;
            _cUBajaCat = cuBajaCat;
            _cUListarCategorias = cuListarCats;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategorias()
        {
            try
            {
                var lista = await _cUListarCategorias.ListarCategorias();
                if (lista == null || !lista.Any())
                    return Ok("En el momento no hay categorias registradas.");

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error interno del servidor", detalle = ex.Message });
            }
        }
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> EliminarCategoria(int id)
        {
            try
            {
                var eliminado = await _cUBajaCat.Eliminar(id);
                if (eliminado==null)
                    return BadRequest("Se produjo un error al eliminar su categoria");
                return Ok($"Categoria {eliminado} eliminada con exito");

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
        public async Task<IActionResult> AltaCategoria(CatDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Los datos ingresados son invalidos");
            try
            {
                CatDTO dtoOut = await _cUAltaCategoria.AltaCategoria(dto);
                return Ok(dtoOut);

            }
            catch (AlreadyExistingEntity ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}
