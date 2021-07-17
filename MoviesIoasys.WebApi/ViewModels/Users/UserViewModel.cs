using MoviesIoasys.Domain.Entities;

namespace MoviesIoasys.WebApi.ViewModels.Users
{
    public class UserViewModel
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string UserRole { get; set; }

        public bool Active { get; set; }

        public static implicit operator UserViewModel(User user)
            => new UserViewModel()
            {
                Email = user.Email,
                Name = user.Name,
                UserRole = user.UserRole.ToString(),
                Active = user.Active
            };
    }
}
