using MoviesIoasys.Domain.Entities;
using MoviesIoasys.Domain.Enums;

namespace MoviesIoasys.Domain.DTOs.Users
{
    public class CreateUserDTO
    {
        public CreateUserDTO(string email,
                             string password,
                             string name,
                             UserRole userRole)
        {
            Email = email;
            Password = password;
            Name = name;
            UserRole = userRole;
        }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public UserRole UserRole { get; set; }

        public static implicit operator User(CreateUserDTO createUserDTO)
            => new User(email: createUserDTO.Email,
                        password: createUserDTO.Password,
                        name: createUserDTO.Name,
                        userRole: createUserDTO.UserRole);
    }
}
