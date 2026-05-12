using Backend_DispenXCore.Api.src.IAM.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Backend_DispenXCore.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly RegisterCommand _register;
        private readonly LoginCommand _login;

        public AuthController(RegisterCommand register, LoginCommand login)
        {
            _register = register;
            _login = login;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string email, string password)
        {
            await _register.Execute(email, password);
            return Ok(new { message = "Usuario registrado correctamente" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var token = await _login.Execute(email, password);
            if (token == null)
                return Unauthorized(new { message = "Credenciales inválidas" });

            return Ok(new { token });
        }
    }
}