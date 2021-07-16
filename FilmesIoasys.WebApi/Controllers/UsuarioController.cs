using FilmesIoasys.Dominio.Interfaces.Services;
using FilmesIoasys.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmesIoasys.WebApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServico _usuarioServico;
        public UsuarioController(IUsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CadastroUsuario([FromBody] CriaUsuarioViewModel criaUsuarioViewModel)
        {
            var usuario = _usuarioServico.CriaUsuario(criaUsuarioViewModel);

            if (!usuario.IsValid)
                return BadRequest(usuario.NotificacaoErro);

            return Created("", (UsuarioViewModel)usuario);
        }
    }
}
