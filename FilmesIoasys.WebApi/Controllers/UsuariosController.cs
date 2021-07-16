using System.Linq;
using FilmesIoasys.Dominio.Interfaces.Services;
using FilmesIoasys.WebApi.Services;
using FilmesIoasys.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmesIoasys.WebApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioServico _usuarioServico;
        public UsuariosController(IUsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult RecuperaUsuariosNaoAdminAtivos([FromQuery] int pagina = 0,
                                                            int tamanho = 5)
        {
            var usuarios = _usuarioServico.RecuperaUsuariosNaoAdmAtivos(pagina, tamanho);

            return Ok(usuarios.Select(usuario => (UsuarioViewModel)usuario));
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

        [HttpPatch]
        [Authorize]
        public IActionResult MudaStatusAtivo([FromBody] AtualizaStatusUsuarioViewModel atualizaStatusUsuarioViewModel)
        {
            string email = TokenServico.RecuperaEmailDoToken(User);

            var usuario = _usuarioServico.MudaStatusAtivo(email, atualizaStatusUsuarioViewModel.Ativo);

            return Ok((UsuarioViewModel)usuario);
        }
    }
}
