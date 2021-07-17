using MoviesIoasys.Domain.DTOs.Users;
using MoviesIoasys.Domain.Entities;
using MoviesIoasys.Domain.Interfaces.Repositories;
using MoviesIoasys.Domain.Provider;

namespace MoviesIoasys.Domain.Services.Users
{
    public class LoginService
    {
        private readonly IUsersRepository _usersRepository;

        public LoginService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public User Login(LoginDTO loginDTO)
        {
            var user = _usersRepository.GetUserByEmail(loginDTO.Email);

            if (!user?.Exists() ?? true)
                return new User().GetInvalidUser("E-mail não cadastrado.");

            bool correctPassword = EncryptProvider.ComparePassword(loginDTO.Password, user.Password);

            if (!correctPassword)
                return new User().GetInvalidUser("Senha incorreta.");

            return user;
        }
    }
}
