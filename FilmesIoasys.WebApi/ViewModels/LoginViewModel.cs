using System.ComponentModel.DataAnnotations;

namespace FilmesIoasys.WebApi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O E-mail deve estar preenchido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha deve estar preenchida.")]
        public string Senha { get; set; }
    }
}