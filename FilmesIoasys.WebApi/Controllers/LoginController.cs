using FilmesIoasys.Dominio.Interfaces.Services;
using FilmesIoasys.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmesIoasys.WebApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioServico _usuarioServico;
        public LoginController(IUsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            var usuario = _usuarioServico.Login(loginViewModel.Email,
                                                loginViewModel.Senha);
            if (!usuario.IsValid)
                return BadRequest(usuario.NotificacaoErro);

            return Ok(AuthViewModel.RecuperaUsuarioToken(usuario));
        }
    }
}
