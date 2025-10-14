using Microsoft.AspNetCore.Mvc;
using store.DTOs.DTOs.User;
using store.DTOs.DTOs.User.Authorization;
using store.LogicaAplicacion.CU.CUUsuarios;
using store.LogicaNegocio.CustomExceptions.UserExceptions;

namespace projectAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizacionController : ControllerBase
    {
        private readonly Authorizations _CUauthorizations;
        public AuthorizacionController(Authorizations cUauthorizations)
        {
            _CUauthorizations = cUauthorizations;
        }
        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                UserOutputDTO token = await _CUauthorizations.LoginAsync(dto);
                return Ok(token);
            }
            catch (NotExistingUser ex)
            {
                return NotFound(ex.Message);
            }
            catch (IncorrectPassword ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor");
            }


        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistroDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                UserOutputDTO token = await _CUauthorizations.RegistrarAsync(dto);
                return Ok(token);
            }
            catch (PasswordsDontMatch ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ExistingUser ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
