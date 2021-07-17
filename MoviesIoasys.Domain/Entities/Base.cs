using Flunt.Notifications;
using System;
using System.Linq;

namespace MoviesIoasys.Domain.Entities
{
    public abstract class Base : Notifiable<Notification>
    {
        public Guid Id { get; protected set; }

        protected abstract void Validate();

        public string NotificationError
            => this.Notifications?.FirstOrDefault()?.Message ?? "";

        public Guid GenerateNewGuid()
            => Guid.NewGuid();
    }
}
