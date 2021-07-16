using Flunt.Notifications;
using Flunt.Validations;

namespace FilmesIoasys.Dominio.Entidades
{
    public class Usuario : Base
    {
        public string Nome { get; private set; }
        public int Idade { get; private set; }
        public bool Ativo { get; private set; }
        public bool Administrador { get; private set; }

        protected override void Validate()
        {
            AddNotifications(new Contract<Notification>()
                .IsNullOrEmpty(Nome, "Nome", "O campo nome deve estar preenchido.")
                .IsLowerThan(Idade, 1, "Idade", "O campo idade deve ser maior que zero.")
                .IsNull(Ativo, "Ativo", "O campo ativo deve estar preenchido")
                .IsNull(Administrador, "Administrador", "O campo ativo deve estar preenchido"));
        }
    }
}
