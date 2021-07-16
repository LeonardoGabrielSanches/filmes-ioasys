using FilmesIoasys.Dominio.Entidades;
using FilmesIoasys.Dominio.Interfaces.Services;
using FilmesIoasys.WebApi.Services;
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

            return Ok(Auth.RecuperaUsuarioToken(usuario));
        }
    }

    struct Auth
    {
        public UsuarioViewModel Usuario { get; set; }
        public string Token { get; set; }

        public static Auth RecuperaUsuarioToken(Usuario usuario)
        {
            var auth = new Auth();

            auth.Usuario = (UsuarioViewModel)usuario;
            auth.Token = TokenServico.GeraToken(usuario);

            return auth;
        }
    }
}
