using Flunt.Notifications;
using Flunt.Validations;

namespace FilmesIoasys.Dominio.Entidades
{
    public class Pessoa : Base
    {
        public string Nome { get; private set; }
        public int Idade { get; private set; }

        protected override void Validate()
        {
            AddNotifications(new Contract<Notification>()
                .IsNullOrEmpty(Nome, "Nome", "O campo nome deve estar preenchido.")
                .IsLowerThan(Idade, 1, "Idade", "O campo idade deve ser maior que zero."));
        }
    }
}
