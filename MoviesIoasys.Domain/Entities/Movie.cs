using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesIoasys.Domain.Entities
{
    public class Movie : Base
    {
        public Movie()
        {
        }

        public Movie(string title,
                     string description,
                     Guid directorId,
                     ICollection<Guid> castIds,
                     Guid categoryId)
        {
            Title = title;
            Description = description;
            DirectorId = directorId;
            CategoryId = categoryId;

            ApplyActorMovies(castIds);

            Validate();
        }


        public string Title { get; private set; }

        public string Description { get; private set; }


        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }


        public Guid DirectorId { get; private set; }
        public Director Director { get; private set; }


        public ICollection<ActorMovie> ActorMovies { get; private set; }

        public IEnumerable<Vote> Votes { get; set; }
        public decimal Rating { get; private set; }

        protected override void Validate()
        {
            AddNotifications(new Contract<Notification>()
               .IsNotNullOrEmpty(Title, "Título", "O campo título deve estar preenchido.")
               .IsNotNullOrEmpty(Description, "Sinopse", "O campo sinopse deve estar preenchido.")
               .IsNotNullOrEmpty(DirectorId.ToString(), "Diretor", "O campo id diretor deve estar preenchido.")
               .IsFalse(ActorMovies?.Any(actor => string.IsNullOrEmpty(actor.ActorId.ToString())) ?? true, "Ator", "O campo id ator deve estar preenchido.")
               .IsNotNullOrEmpty(CategoryId.ToString(), "Gênero", "O campo id categoria deve estar preenchido."));
        }

        public Movie GetInvalidMovie(string errorMessage)
        {
            this.AddNotification(nameof(Movie), errorMessage);
            return this;
        }

        private void ApplyActorMovies(IEnumerable<Guid> castIds)
        {
            ActorMovies = new List<ActorMovie>();

            foreach (var actorId in castIds)
                ActorMovies.Add(new ActorMovie(actorId: actorId, movieId: Id));
        }

        public void CalculateRating()
        {
            var totalValue = Votes.Sum(x => x.Value);
            var totalVotes = Votes.Count();

            if (totalVotes > 0)
                Rating = totalValue / totalVotes;
            else
                Rating = 0;
        }
    }
}
