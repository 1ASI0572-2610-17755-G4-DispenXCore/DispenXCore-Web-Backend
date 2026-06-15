using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Backend_DispenXCore.Api.src.Dispensadores.Application.UseCases;

namespace Backend_DispenXCore.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/dispensators")]
    [ApiController]
    [Authorize]
    public class DispensatorsController : ControllerBase
    {
        private readonly ObtenerDispensatorsQuery _getAll;
        private readonly ObtenerDispensatorStatusQuery _getStatus;

        public DispensatorsController(
            ObtenerDispensatorsQuery getAll,
            ObtenerDispensatorStatusQuery getStatus)
        {
            _getAll = getAll;
            _getStatus = getStatus;
        }

        /// <summary>
        /// Obtiene la lista de todos los dispensadores registrados.
        /// </summary>
        /// <returns>Lista de dispensadores con ID, nombre, estado y capacidad máxima.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dispensadores = await _getAll.Execute();
            return Ok(dispensadores);
        }

        /// <summary>
        /// Obtiene el estado detallado de un dispensador específico.
        /// Calcula dinámicamente nextDispenseAt y dailyTotal.
        /// </summary>
        /// <param name="id">ID del dispensador.</param>
        /// <returns>Estado actual del dispensador con capacidad, total diario y próxima dispensación.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var status = await _getStatus.Execute(id);
            if (status == null)
                return NotFound(new { message = $"No se encontró el dispensador con ID {id}" });

            return Ok(status);
        }
    }
}