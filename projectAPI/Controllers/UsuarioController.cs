using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using store.DTOs.DTOs.User;
using store.LogicaAplicacion.ICU.ICUUsuarios;
using store.LogicaNegocio.CustomExceptions;
using store.LogicaNegocio.CustomExceptions.ProdExceptions;
using store.LogicaNegocio.CustomExceptions.UserExceptions;
using System.Data;
using System.Security.Claims;

namespace projectAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsuarioController : Controller
    {
        private readonly ICUChangePass _cUChangePass;
        private readonly ICUAgregarFavorito _cUAgregarFavorito;
        private readonly ICUEliminarFavorito _cUEliminarFavorito;
        private readonly ICUListarFavoritos _cUListarFavoritos;
        public UsuarioController(ICUChangePass cuChangePass, ICUAgregarFavorito cuAgregarFavorito, ICUEliminarFavorito cuEliminarFavorito, ICUListarFavoritos cuListarFavoritos)
        {
            _cUChangePass = cuChangePass;
            _cUAgregarFavorito = cuAgregarFavorito;
            _cUEliminarFavorito=cuEliminarFavorito;
            _cUListarFavoritos=cuListarFavoritos;
        }
        [HttpGet("favoritos")]
        [Authorize(Roles = "Cliente")]
        public async Task<IActionResult> ListarFavoritos()
        {
            var idS = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int id = Convert.ToInt32(idS);
            if (id == null)
            {
                return Unauthorized("No se pudo obtener el ID del usuario autenticado.");
            }
            try
            {
                var lista = await _cUListarFavoritos.ListarFavoritos(id);
                if (lista == null || lista.Count == 0)
                    return Ok("Por el momento no tiene productos favoritos.");
                return Ok(lista);
            }
            catch (EntityNotFound ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex) {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        [HttpPost("AltaFavorito")]
        [Authorize(Roles = "Cliente")]
        public async Task<IActionResult> AltaFavorito([FromQuery] Guid prodGuid)
        {
            var idS = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int id = Convert.ToInt32(idS);
            if (id == null)
            {
                return Unauthorized("No se pudo obtener el ID del usuario autenticado.");
            }
            try
            {
                 await _cUAgregarFavorito.AgregarProductoFavorito(id,prodGuid);
                return Ok("Producto agregado con exito.");
            }
            catch (EntityNotFound ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ProductoEnFavoritos ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        [HttpDelete("BajaFavorito")]
        [Authorize(Roles = "Cliente")]
        public async Task<IActionResult> BajaFavorito([FromQuery] Guid prodGuid)
        {
            var idS = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int id = Convert.ToInt32(idS);
            if (id == null)
            {
                return Unauthorized("No se pudo obtener el ID del usuario autenticado.");
            }
            try
            {
                await _cUEliminarFavorito.EliminarProductoFavorito(id, prodGuid);
                return Ok("Producto Eliminado con exito.");
            }
            catch (EntityNotFound ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ProductoEnFavoritos ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost("change-pass")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePassDTO dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var email = User.FindFirst(ClaimTypes.Email)?.Value;

            
            if(email == null)
            {
                return Unauthorized("No se pudo obtener el email del usuario autenticado.");
            }
            try
            {
                await _cUChangePass.ChangePass(email, dto);
                return Ok("Contraseña cambiada exitosamente.");
            }
            catch (NotExistingUser ex)
            {
                return NotFound(ex.Message);
            }
            catch (PasswordsDontMatch ex)
            {
                return BadRequest(ex.Message);
            }
            catch (IncorrectPassword ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }

        }

    }
}
