using FilmesIoasys.Dominio.Enums;
using Flunt.Notifications;
using Flunt.Validations;

namespace FilmesIoasys.Dominio.Entidades
{
    public class Usuario : Base
    {
        public Usuario()
        {
        }

        public Usuario(
            string email,
            string senha,
            string nome,
            TipoUsuario tipoUsuario
        )
        {
            Id = GeraNovoGuid();
            Email = email;
            Senha = senha;
            Nome = nome;
            Ativo = true;
            TipoUsuario = tipoUsuario;
        }

        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }
        public TipoUsuario TipoUsuario { get; private set; }

        protected override void Valida()
        {
            AddNotifications(new Contract<Notification>()
                .IsNotEmail(Email, "Email", "O campo e-mail deve ser do tipo e-mail.")
                .IsNotNullOrEmpty(Email, "Email", "O campo e-mail deve estar preenchido.")
                .IsNotNullOrEmpty(Senha, "Senha", "O campo senha deve estar preenchido.")
                .IsNotNullOrEmpty(Nome, "Nome", "O campo nome deve estar preenchido.")
                .IsNotNull(Ativo, "Ativo", "O campo ativo deve estar preenchido")
                .IsNotNull(TipoUsuario, "Tipo do usuário", "O campo tipo do usuário deve estar preenchido"));
        }

        public void AplicaSenhaCriptografada(string senhaCriptografada)
            => Senha = senhaCriptografada;

        public Usuario RecuperaUsuarioInvalido(string mensagemErro)
        {
            this.AddNotification(nameof(Usuario), mensagemErro);
            return this;
        }

        public void AtualizaStatusAtivo(bool ativo)
            => Ativo = ativo;
    }
}
