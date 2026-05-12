using Backend_DispenXCore.Api.src.Usuarios.Application.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Backend_DispenXCore.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/perfil")]
    [ApiController]
    [Authorize]
    public class UsuariosController : ControllerBase
    {
        private readonly CrearPerfilCommand _crearPerfil;
        private readonly VincularDispensadorCommand _vincular;

        public UsuariosController(CrearPerfilCommand crearPerfil, VincularDispensadorCommand vincular)
        {
            _crearPerfil = crearPerfil;
            _vincular = vincular;
        }

        [HttpPost]
        public async Task<IActionResult> CrearPerfil(string nombreCompleto)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            await _crearPerfil.Execute(userId, nombreCompleto);
            return Ok();
        }

        [HttpPost("vincular-dispensador")]
        public async Task<IActionResult> VincularDispensador(string codigo)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            await _vincular.Execute(userId, codigo);
            return Ok();
        }
    }
}