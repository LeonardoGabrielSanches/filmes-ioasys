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
                     Director director,
                     ICollection<Actor> cast,
                     Category category)
        {
            Title = title;
            Description = description;
            Director = director;
            Cast = cast;
            Category = category;

            Validate();
        }

        
        public string Title { get; private set; }
        
        public string Description { get; private set; }

        
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }

        
        public Guid DirectorId { get; private set; }
        public Director Director { get; private set; }

        
        public ICollection<ActorMovie> ActorMovies { get; private set; }
        public IEnumerable<Actor> Cast { get; private set; }

        protected override void Validate()
        {
            AddNotifications(new Contract<Notification>()
               .IsNotNullOrEmpty(Title, "Título", "O campo título deve estar preenchido.")
               .IsNotNullOrEmpty(Description, "Sinopse", "O campo sinopse deve estar preenchido.")
               .IsTrue(Director.IsValid, "Diretor", Director.NotificationError)
               .IsFalse(Cast.Any(actor => !actor.IsValid), "Ator", Cast.FirstOrDefault(actor => !actor.IsValid)?.NotificationError ?? string.Empty)
               .IsTrue(Category.IsValid, "Gênero", Category.NotificationError));
        }

        public Movie GetInvalidMovie(string errorMessage)
        {
            this.AddNotification(nameof(Movie), errorMessage);
            return this;
        }

        public void ApplyDirectorId(Director director)
        {
            Director = null;
            DirectorId = director.Id;
        }


        public void ApplyCategoryId(Category category)
        {
            Category = null;
            CategoryId = category.Id;
        }

        public void ApplyActorMovies(IEnumerable<Actor> cast)
        {
            ActorMovies = new List<ActorMovie>();

            foreach (var actor in cast)
                ActorMovies.Add(new ActorMovie(actorId: actor.Id, movieId: Id));
        }
    }
}
