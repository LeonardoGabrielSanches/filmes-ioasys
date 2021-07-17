using MoviesIoasys.Domain.DTOs.Users;
using MoviesIoasys.Domain.Entities;
using MoviesIoasys.Domain.Interfaces.Repositories;

namespace MoviesIoasys.Domain.Services.Users
{
    public class UpdateActiveStatusService
    {
        private readonly IUsersRepository _usersRepository;

        public UpdateActiveStatusService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public User UpdateActiveStatus(UpdateUserActiveStatusDTO updateActiveStatusDTO)
        {
            var user = _usersRepository.GetUserByEmail(updateActiveStatusDTO.Email);

            if (!user?.Exists() ?? true)
                return new User().GetInvalidUser("E-mail não cadastrado.");

            user.UpdateActive(updateActiveStatusDTO.Active);

            _usersRepository.Update(user);

            return user;
        }
    }
}
