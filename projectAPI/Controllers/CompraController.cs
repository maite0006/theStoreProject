using Microsoft.AspNetCore.Mvc;
using store.DTOs.DTOs.Compra;
using store.LogicaAplicacion.CU.CUCompra;
using store.LogicaAplicacion.ICU.ICUCompra;
using store.LogicaAplicacion.ICU.ICUCompra.ICUPagos;

namespace projectAPI.Controllers
{
    [ApiController]
    [Route("api/compras")]
    public class ComprasController : ControllerBase
    {
        private readonly ICUConfigurarCompra _configurarCompra;// inyeccion de ambos pendiente
     

        public ComprasController(ICUConfigurarCompra configurarCompra)
        {
            _configurarCompra = configurarCompra;
            
        }

        [HttpPost("{compraId}/configurar")]
        public async Task<IActionResult> ConfigurarCompra(int compraId, [FromBody] EnvioDTO envioDto)
        {
            int id = await _configurarCompra.ConfiguraciónCompra(compraId, envioDto);
            return Ok(new { compraId = id });
        }

       
    }
}
