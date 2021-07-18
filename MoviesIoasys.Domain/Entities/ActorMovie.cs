using System;

namespace MoviesIoasys.Domain.Entities
{
    public class ActorMovie
    {
        public ActorMovie(Guid actorId,
                          Guid movieId)
        {
            ActorId = actorId;
            MovieId = movieId;
        }

        public Guid ActorId { get; private set; }
        public Actor Actor { get; private set; }
        public Guid MovieId { get; private set; }
        public Movie Movie { get; private set; }
    }
}
