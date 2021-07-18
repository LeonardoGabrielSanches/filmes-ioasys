using System;
using MoviesIoasys.Domain.Entities;

namespace MoviesIoasys.WebApi.ViewModels.Actors
{
    public class ActorViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public static implicit operator ActorViewModel(Actor actor)
            => new ActorViewModel()
            {
                Id = actor.Id,
                Name = actor.Name
            };
    }
}