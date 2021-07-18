using MoviesIoasys.Domain.Entities;

namespace MoviesIoasys.Domain.Interfaces.Repositories
{
    public interface IMoviesRepository
    {
        Movie Save(Movie movie);
    }
}
