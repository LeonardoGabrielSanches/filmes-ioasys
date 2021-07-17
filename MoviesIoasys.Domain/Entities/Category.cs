using Flunt.Notifications;
using Flunt.Validations;

namespace MoviesIoasys.Domain.Entities
{
    public class Category : Base
    {
        public string Name { get; private set; }

        protected override void Validate()
        {
            AddNotifications(new Contract<Notification>()
               .IsNotNullOrEmpty(Name, "Nome", "O campo nome deve estar preenchido."));
        }
    }
}
