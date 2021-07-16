using Flunt.Notifications;
using Flunt.Validations;
using System.Collections.Generic;
using System.Linq;

namespace FilmesIoasys.Dominio.Entidades
{
    public class Filme : Base
    {
        public string Titulo { get; private set; }
        public string Sinopse { get; private set; }
        public Pessoa Diretor { get; private set; }
        public IEnumerable<Pessoa> Atores { get; private set; }
        public Genero Genero { get; private set; }

        protected override void Validate()
        {
            AddNotifications(new Contract<Notification>()
               .IsNullOrEmpty(Titulo, "Título", "O campo título deve estar preenchido.")
               .IsNullOrEmpty(Sinopse, "Sinopse", "O campo sinopse deve estar preenchido.")
               .IsFalse(Diretor.IsValid, "Diretor", Diretor.NotificationError)
               .IsTrue(Atores.Any(ator => !ator.IsValid), "Ator", Atores.FirstOrDefault(ator => !ator.IsValid).NotificationError)
               .IsFalse(Genero.IsValid, "Gênero", Genero.NotificationError));
        }
    }
}
