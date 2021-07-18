using MoviesIoasys.Domain.Entities;
using System;

namespace MoviesIoasys.Domain.Interfaces.Repositories
{
    public interface IVotesRepository
    {
        Vote Save(Vote vote);
        decimal GetMovieRating(Guid movieId);
    }
}
