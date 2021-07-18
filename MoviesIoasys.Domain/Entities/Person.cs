using Flunt.Notifications;
using Flunt.Validations;
using System.ComponentModel.DataAnnotations;

namespace MoviesIoasys.Domain.Entities
{
    public abstract class Person : Base
    {
        protected Person(string name)
        {
            Id = GenerateNewGuid();
            Name = name;
        }

        [Required]
        public string Name { get; private set; }

        protected override void Validate()
        {
            AddNotifications(new Contract<Notification>()
                .IsNotNullOrEmpty(Name, "Nome", "O campo nome deve estar preenchido."));
        }
    }
}
