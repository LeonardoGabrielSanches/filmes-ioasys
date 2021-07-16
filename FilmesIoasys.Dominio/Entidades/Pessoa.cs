using Flunt.Notifications;
using Flunt.Validations;

namespace FilmesIoasys.Dominio.Entidades
{
    public class Pessoa : Base
    {
        public string Nome { get; private set; }

        protected override void Valida()
        {
            AddNotifications(new Contract<Notification>()
                .IsNotNullOrEmpty(Nome, "Nome", "O campo nome deve estar preenchido."));
        }
    }
}
