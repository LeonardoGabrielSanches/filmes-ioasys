using MoviesIoasys.Domain.DTOs.Users;
using System.ComponentModel.DataAnnotations;

namespace MoviesIoasys.WebApi.ViewModels.Users
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O E-mail deve estar preenchido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha deve estar preenchida.")]
        public string Password { get; set; }

        public static implicit operator LoginDTO(LoginViewModel loginViewModel)
            => new LoginDTO(email: loginViewModel.Email,
                            password: loginViewModel.Password);
    }
}
