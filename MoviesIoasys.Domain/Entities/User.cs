using Flunt.Notifications;
using Flunt.Validations;
using MoviesIoasys.Domain.Enums;
using System;

namespace MoviesIoasys.Domain.Entities
{
    public class User : Base
    {
        public User()
        {
        }

        public User(
            string email,
            string password,
            string name,
            UserRole userRole
        )
        {
            Id = GenerateNewGuid();
            Email = email;
            Password = password;
            Name = name;
            Active = true;
            UserRole = userRole;

            Validate();
        }

        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }
        public bool Active { get; private set; }
        public UserRole UserRole { get; private set; }

        protected override void Validate()
        {
            AddNotifications(new Contract<Notification>()
                .IsEmail(Email, "Email", "O campo e-mail deve ser do tipo e-mail.")
                .IsNotNullOrEmpty(Email, "Email", "O campo e-mail deve estar preenchido.")
                .IsNotNullOrEmpty(Password, "Senha", "O campo senha deve estar preenchido.")
                .IsNotNullOrEmpty(Name, "Nome", "O campo nome deve estar preenchido.")
                .IsNotNull(Active, "Ativo", "O campo ativo deve estar preenchido")
                .IsNotNull(UserRole, "Tipo do usuário", "O campo tipo do usuário deve estar preenchido"));
        }

        public void ApplyEncryptedPassword(string encryptedPassword)
            => Password = encryptedPassword;

        public User GetInvalidUser(string errorMessage)
        {
            this.AddNotification(nameof(User), errorMessage);
            return this;
        }

        public void UpdateActive(bool active)
            => Active = active;

        public bool Exists()
            => !string.IsNullOrEmpty(Id.ToString()) || Id != System.Guid.Empty;

        public void UpdateUser(string email,string name,UserRole userRole)
        {
            Email = email;
            Name = name;
            UserRole = userRole;
        }
    }
}
