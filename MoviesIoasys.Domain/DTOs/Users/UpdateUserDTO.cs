using MoviesIoasys.Domain.Enums;
using System;

namespace MoviesIoasys.Domain.DTOs.Users
{
    public class UpdateUserDTO
    {
        public UpdateUserDTO(Guid id,
                             string email,
                             string newPassword,
                             string oldPassword,
                             string name,
                             UserRole userRole)
        {
            Id = id;
            Email = email;
            NewPassword = newPassword;
            OldPassword = oldPassword;
            Name = name;
            UserRole = userRole;
        }

        public Guid Id { get; set; }

        public string Email { get; set; }

        public string NewPassword { get; set; }

        public string OldPassword { get; set; }

        public string Name { get; set; }

        public UserRole UserRole { get; set; }

        public bool WithNewPasswordButWithNotOldPassword
            => !string.IsNullOrEmpty(NewPassword) && string.IsNullOrEmpty(OldPassword);

        public bool WithNewAndOldPassword
            => !string.IsNullOrEmpty(NewPassword) && !string.IsNullOrEmpty(OldPassword);
    }
}
