using FilmesIoasys.Dominio.Entidades;
using FilmesIoasys.WebApi.Services;

namespace FilmesIoasys.WebApi.ViewModels
{
    public class AuthViewModel
    {
        public UsuarioViewModel Usuario { get; set; }
        public string Token { get; set; }

        public static AuthViewModel RecuperaUsuarioToken(Usuario usuario)
        {
            var auth = new AuthViewModel();

            auth.Usuario = (UsuarioViewModel)usuario;
            auth.Token = TokenServico.GeraToken(usuario);

            return auth;
        }
    }
}