using Flunt.Notifications;
using Flunt.Validations;
using System.Collections.Generic;
using System.Linq;

namespace MoviesIoasys.Domain.Entities
{
    public class Movie : Base
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public Director Director { get; private set; }
        public IEnumerable<Actor> Cast { get; private set; }
        public Category Category { get; private set; }

        protected override void Validate()
        {
            AddNotifications(new Contract<Notification>()
               .IsNullOrEmpty(Title, "Título", "O campo título deve estar preenchido.")
               .IsNullOrEmpty(Description, "Sinopse", "O campo sinopse deve estar preenchido.")
               .IsFalse(Director.IsValid, "Diretor", Director.NotificationError)
               .IsTrue(Cast.Any(ator => !ator.IsValid), "Ator", Cast.FirstOrDefault(ator => !ator.IsValid).NotificationError)
               .IsFalse(Category.IsValid, "Gênero", Category.NotificationError));
        }
    }
}
