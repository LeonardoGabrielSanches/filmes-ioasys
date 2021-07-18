using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace MoviesIoasys.Domain.Entities
{
    public class Vote : Base
    {
        public Vote(decimal value,
                    Guid movieId)
        {
            Id = GenerateNewGuid();
            Value = value;
            MovieId = movieId;
        }

        public decimal Value { get; private set; }
        public Guid MovieId { get; private set; }
        public Movie Movie { get; private set; }

        protected override void Validate()
        {
            AddNotifications(new Contract<Notification>()
                .IsBetween(Value, 0, 4, "Valor", "O valor do voto deve estar entre 0 e 4."));
        }
    }
}
