using MoviesIoasys.Domain.DTOs.Users;
using MoviesIoasys.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MoviesIoasys.WebApi.ViewModels.Users
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "O Email deve estar preenchido.")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha deve estar preenchida.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "A senha e a confirmação de senha devem ser iguais.")]
        public string PasswordConfirmation { get; set; }

        [Required(ErrorMessage = "O nome deve estar preenchido.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O tipo do usuário deve estar preenchido.")]
        [EnumDataType(typeof(UserRole), ErrorMessage = "Deve ser informado 0(Admin) ou 1(Usuário).")]
        public UserRole UserRole { get; set; }

        public static implicit operator CreateUserDTO(CreateUserViewModel createUserViewModel)
        {
            return new CreateUserDTO(email: createUserViewModel.Email,
                                     password: createUserViewModel.Password,
                                     name: createUserViewModel.Name,
                                     userRole: createUserViewModel.UserRole);
        }
    }
}
