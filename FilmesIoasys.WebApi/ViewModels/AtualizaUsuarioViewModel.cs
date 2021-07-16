using System.ComponentModel.DataAnnotations;
using FilmesIoasys.Dominio.Entidades;
using FilmesIoasys.Dominio.Enums;

namespace FilmesIoasys.WebApi.ViewModels
{
    public class AtualizaUsuarioViewModel
    {
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        public string NovaSenha { get; set; }

        [Compare("NovaSenha", ErrorMessage = "A senha e a confirmação de senha não são iguais")]
        public string ConfirmacaoSenha { get; set; }

        [Required(ErrorMessage = "O nome deve estar preenchido.")]
        public string Nome { get; set; }

        [EnumDataType(typeof(TipoUsuario))]
        public TipoUsuario TipoUsuario { get; set; }

        public static implicit operator Usuario(CriaUsuarioViewModel usuarioViewModel)
        {
            return new Usuario(email: usuarioViewModel.Email,
                               senha: usuarioViewModel.Senha,
                               nome: usuarioViewModel.Nome,
                               tipoUsuario: usuarioViewModel.TipoUsuario);
        }
    }
}