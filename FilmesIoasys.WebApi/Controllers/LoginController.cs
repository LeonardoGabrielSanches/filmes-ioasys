using FilmesIoasys.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmesIoasys.WebApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login()
        {
            return Ok(TokenService.GeraToken(new Dominio.Entidades.Usuario(
                "a@gmail.com",
                "1234",
                "Leonardo",
                Dominio.Enums.TipoUsuario.Admin)));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GET()
        {
            var email = TokenService.RecuperaEmailDoToken(User);

            return Created("", email);
        }
    }
}
