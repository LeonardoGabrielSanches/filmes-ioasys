using System;
using System.Collections.Generic;

namespace MoviesIoasys.Domain.Entities
{
    public class Actor : Person
    {
        public Actor(Guid id,
                     string name) : base(name)
        {
            Id = id;

            Validate();
        }

        public Actor(string name) : base(name)
        {
            Validate();
        }

        public ICollection<ActorMovie> ActorMovies { get; private set; }
    }
}
