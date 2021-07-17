using MoviesIoasys.Domain.Entities;
using MoviesIoasys.WebApi.Provider;
using MoviesIoasys.WebApi.ViewModels.Users;

namespace MoviesIoasys.WebApi.ViewModels
{
    public class AuthViewModel
    {
        public UserViewModel User { get; set; }
        public string Token { get; set; }

        public static AuthViewModel GenerateUserToken(User user)
        {
            var auth = new AuthViewModel();

            auth.User = user;
            auth.Token = TokenProvider.GenerateToken(user);

            return auth;
        }
    }
}
