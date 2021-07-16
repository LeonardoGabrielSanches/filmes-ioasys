using Flunt.Notifications;
using Flunt.Validations;

namespace FilmesIoasys.Dominio.Entidades
{
    public class Genero : Base
    {
        public string Nome { get; private set; }

        protected override void Validate()
        {
            AddNotifications(new Contract<Notification>()
               .IsNotNullOrEmpty(Nome, "Nome", "O campo nome deve estar preenchido."));
        }
    }
}
