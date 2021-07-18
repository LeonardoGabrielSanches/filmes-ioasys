using MoviesIoasys.Domain.Entities;
using System;

namespace MoviesIoasys.Domain.Interfaces.Repositories
{
    public interface IMoviesRepository
    {
        Movie Save(Movie movie);
        Movie Get(Guid id);
    }
}
