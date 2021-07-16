using FilmesIoasys.Dominio.Entidades;
using FilmesIoasys.Dominio.Enums;

namespace FilmesIoasys.WebApi.ViewModels
{
    public class UsuarioViewModel
    {

        public string Email { get; set; }

        public string Nome { get; set; }

        public string TipoUsuario { get; set; }

        public bool Ativo { get; set; }

        public static implicit operator UsuarioViewModel(Usuario usuario)
            => new UsuarioViewModel()
            {
                Email = usuario.Email,
                Nome = usuario.Nome,
                TipoUsuario = usuario.TipoUsuario.ToString(),
                Ativo = usuario.Ativo
            };
    }
}