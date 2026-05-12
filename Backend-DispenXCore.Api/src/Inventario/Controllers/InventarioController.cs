using Backend_DispenXCore.Api.src.Inventario.Application.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend_DispenXCore.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/inventario")]
    [ApiController]
    [Authorize]
    public class InventarioController : ControllerBase
    {
        private readonly RegistrarMedicionCommand _registrarMedicion;
        private readonly ObtenerEstadoGranoQuery _obtenerEstado;

        public InventarioController(RegistrarMedicionCommand registrarMedicion,
            ObtenerEstadoGranoQuery obtenerEstado)
        {
            _registrarMedicion = registrarMedicion;
            _obtenerEstado = obtenerEstado;
        }

        [HttpPost("medicion")]
        public async Task<IActionResult> RegistrarMedicion(Guid contenedorId, double peso, double nivel, double flujo)
        {
            await _registrarMedicion.Execute(contenedorId, peso, nivel, flujo);
            return Ok();
        }

        [HttpGet("estado")]
        public async Task<IActionResult> ObtenerEstado()
        {
            var resultado = await _obtenerEstado.Execute();
            return Ok(resultado);
        }
    }
}