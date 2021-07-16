using Flunt.Notifications;
using System;
using System.Linq;

namespace FilmesIoasys.Dominio.Entidades
{
    public abstract class Base : Notifiable<Notification>
    {
        public Guid Id { get; protected set; }

        protected abstract void Valida();

        public string NotificacaoErro
            => this.Notifications?.FirstOrDefault()?.Message ?? "";

        public Guid GeraNovoGuid()
            => Guid.NewGuid();
    }
}
