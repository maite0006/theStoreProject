using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using store.DTOs.DTOs.User;
using store.LogicaAplicacion.ICU.ICUUsuarios;
using store.LogicaNegocio.CustomExceptions.UserExceptions;
using System.Security.Claims;

namespace projectAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly ICUChangePass _cuChangePass;
        public UsuarioController(ICUChangePass cuChangePass)
        {
            _cuChangePass = cuChangePass;
        }
        [Authorize]
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
                await _cuChangePass.ChangePass(email, dto);
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
