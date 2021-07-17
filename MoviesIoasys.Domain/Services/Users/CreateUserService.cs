using MoviesIoasys.Domain.DTOs.Users;
using MoviesIoasys.Domain.Entities;
using MoviesIoasys.Domain.Interfaces.Repositories;
using MoviesIoasys.Domain.Provider;

namespace MoviesIoasys.Domain.Services.Users
{
    public class CreateUserService
    {
        private readonly IUsersRepository _usersRepository;

        public CreateUserService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public User CreateUser(CreateUserDTO createUserDTO)
        {
            var user = (User)createUserDTO;

            if (!user.IsValid)
                return user;

            var userDB = _usersRepository.GetUserByEmail(user.Email);

            if (userDB?.Exists() ?? false)
                return new User().GetInvalidUser("E-mail já cadastrado.");

            string encryptedPassword = EncryptProvider.EncryptPassword(user.Password);

            user.ApplyEncryptedPassword(encryptedPassword);

            _usersRepository.Save(user);

            return user;
        }
    }
}
