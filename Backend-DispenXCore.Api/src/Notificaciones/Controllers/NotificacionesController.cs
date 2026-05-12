using Backend_DispenXCore.Api.src.Notificaciones.Application.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend_DispenXCore.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/notificaciones")]
    [ApiController]
    [Authorize]
    public class NotificacionesController : ControllerBase
    {
        private readonly EvaluarAlertasCommand _evaluar;
        private readonly ObtenerAlertasQuery _obtenerAlertas;

        public NotificacionesController(EvaluarAlertasCommand evaluar, ObtenerAlertasQuery obtenerAlertas)
        {
            _evaluar = evaluar;
            _obtenerAlertas = obtenerAlertas;
        }

        [HttpPost("evaluar")]
        public async Task<IActionResult> Evaluar(Guid contenedorId, double umbral, string deviceToken)
        {
            await _evaluar.Execute(contenedorId, umbral, deviceToken);
            return Ok();
        }

        [HttpGet("{contenedorId}")]
        public async Task<IActionResult> ObtenerAlertas(Guid contenedorId)
        {
            var result = await _obtenerAlertas.Execute(contenedorId);
            return Ok(result);
        }
    }
}