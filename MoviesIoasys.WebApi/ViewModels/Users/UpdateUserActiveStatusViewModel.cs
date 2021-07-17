using MoviesIoasys.Domain.DTOs.Users;
using System.ComponentModel.DataAnnotations;

namespace MoviesIoasys.WebApi.ViewModels.Users
{
    public class UpdateUserActiveStatusViewModel
    {
        [Required(ErrorMessage = "O campo ativo deve estar preenchido.")]
        public bool Active { get; set; }

        public static UpdateUserActiveStatusDTO GetUserActiveStatusDTO(UpdateUserActiveStatusViewModel updateUserActiveStatusViewModel,
                                                      string email)
            => new UpdateUserActiveStatusDTO(email: email,
                                             active: updateUserActiveStatusViewModel.Active);
    }
}
