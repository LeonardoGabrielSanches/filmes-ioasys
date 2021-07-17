using MoviesIoasys.Domain.DTOs.Users;
using MoviesIoasys.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MoviesIoasys.WebApi.ViewModels.Users
{
    public class UpdateUserViewModel
    {
        [Required(ErrorMessage = "O Email deve estar preenchido.")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        public string NewPassword { get; set; }

        public string OldPassword { get; set; }

        [Required(ErrorMessage = "O nome deve estar preenchido.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O tipo do usuário deve estar preenchido.")]
        [EnumDataType(typeof(UserRole), ErrorMessage = "Deve ser informado 0(Admin) ou 1(Usuário).")]
        public UserRole UserRole { get; set; }

        public static UpdateUserDTO GetUpdateUserDTO(UpdateUserViewModel updateUserViewModel, string id)
            => new UpdateUserDTO(id: System.Guid.Parse(id),
                                 email: updateUserViewModel.Email,
                                 newPassword: updateUserViewModel.NewPassword,
                                 oldPassword: updateUserViewModel.OldPassword,
                                 name: updateUserViewModel.Name,
                                 userRole: updateUserViewModel.UserRole);
    }
}
