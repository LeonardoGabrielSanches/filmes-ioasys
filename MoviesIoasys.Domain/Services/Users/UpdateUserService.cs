using MoviesIoasys.Domain.DTOs.Users;
using MoviesIoasys.Domain.Entities;
using MoviesIoasys.Domain.Interfaces.Repositories;
using MoviesIoasys.Domain.Provider;

namespace MoviesIoasys.Domain.Services.Users
{
    public class UpdateUserService
    {
        private readonly IUsersRepository _usersRepository;

        public UpdateUserService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public User UpdateUser(UpdateUserDTO updateUserDTO)
        {
            var user = _usersRepository.GetUserById(updateUserDTO.Id);

            if (!user?.Exists() ?? true)
                return new User().GetInvalidUser("Usuário não encontrado.");

            var userWithNewEmail = _usersRepository.GetUserByEmail(updateUserDTO.Email);

            if (NewEmailAlreadyInUse(userWithNewEmail, user.Email))
                return new User().GetInvalidUser("E-mail já está sendo utilizado por outro usuário.");

            user.UpdateUser(updateUserDTO.Email, updateUserDTO.Name, updateUserDTO.UserRole);

            if (updateUserDTO.WithNewPasswordButWithNotOldPassword)
                return new User().GetInvalidUser("É necessário informar a senha antiga para atualizar a nova senha.");

            if (updateUserDTO.WithNewAndOldPassword)
            {
                bool correctPassword = EncryptProvider.ComparePassword(updateUserDTO.OldPassword, user.Password);

                if (!correctPassword)
                    return new User().GetInvalidUser("Senha antiga incorreta.");

                string newPasswordEncrypted = EncryptProvider.EncryptPassword(updateUserDTO.NewPassword);

                user.ApplyEncryptedPassword(newPasswordEncrypted);
            }

            _usersRepository.Update(user);

            return user;
        }

        private bool NewEmailAlreadyInUse(User userWithNewEmail, string userEmail)
            => (userWithNewEmail?.Exists() ?? false) && userWithNewEmail?.Email != userEmail;
    }
}
