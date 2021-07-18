using MoviesIoasys.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MoviesIoasys.Domain.Interfaces.Repositories
{
    public interface IMoviesRepository
    {
        Movie Save(Movie movie);
        Movie Get(Guid id);
        IEnumerable<Movie> GetAll();
    }
}
