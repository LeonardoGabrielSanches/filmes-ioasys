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
    }
}