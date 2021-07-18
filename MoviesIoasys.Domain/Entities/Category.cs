using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace MoviesIoasys.Domain.Entities
{
    public class Category : Base
    {
        public Category(Guid id,
                        string name)
        {
            Id = id;
            Name = name;

            Validate();
        }

        public Category(string name)
        {
            Id = GenerateNewGuid();
            Name = name;

            Validate();
        }

        public string Name { get; private set; }

        protected override void Validate()
        {
            AddNotifications(new Contract<Notification>()
               .IsNotNullOrEmpty(Name, "Nome", "O campo nome deve estar preenchido."));
        }
    }
}
