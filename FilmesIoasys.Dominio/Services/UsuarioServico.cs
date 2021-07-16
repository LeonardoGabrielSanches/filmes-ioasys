using System.Collections.Generic;
using System.Linq;
using FilmesIoasys.Dominio.Entidades;
using FilmesIoasys.Dominio.Interfaces.Repositories;
using FilmesIoasys.Dominio.Interfaces.Services;

namespace FilmesIoasys.Dominio.Services
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioServico(
            IUsuarioRepositorio usuarioRepositorio
        )
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public Usuario CriaUsuario(Usuario usuario)
        {
            if (!usuario.IsValid)
                return usuario;

            var usuarioJaExiste = _usuarioRepositorio.RecuperaUsuarioPorEmail(usuario.Email);

            if (usuarioJaExiste != null)
            {
                usuario.AddNotification(nameof(Usuario), "E-mail já cadastrado");
                return usuario;
            }

            string senhaCriptografada = Criptografia.CriptografarSenha(usuario.Senha);

            usuario.AplicaSenhaCriptografada(senhaCriptografada);

            _usuarioRepositorio.Salvar(usuario);

            return usuario;
        }

        public Usuario Login(string email, string senha)
        {
            var usuario = _usuarioRepositorio.RecuperaUsuarioPorEmail(email);

            if (usuario == null)
                return new Usuario().RecuperaUsuarioInvalido("E-mail não cadastrado.");

            bool senhaCorreta = Criptografia.VerificarSenha(senha, usuario.Senha);

            if (!senhaCorreta)
                return new Usuario().RecuperaUsuarioInvalido("Senha incorreta.");

            return usuario;
        }

        public Usuario MudaStatusAtivo(string email, bool ativo)
        {
            var usuario = _usuarioRepositorio.RecuperaUsuarioPorEmail(email);

            if (usuario == null)
                return new Usuario().RecuperaUsuarioInvalido("E-mail não cadastrado.");

            usuario.AtualizaStatusAtivo(ativo);

            _usuarioRepositorio.AtualizaStatusAtivo(usuario);

            return usuario;
        }

        public IEnumerable<Usuario> RecuperaUsuariosNaoAdmAtivos(int pagina = 0, int tamanho = 5)
            => _usuarioRepositorio.RecuperaTodosUsuariosNaoAdmAtivos(pagina, tamanho);

    }
}