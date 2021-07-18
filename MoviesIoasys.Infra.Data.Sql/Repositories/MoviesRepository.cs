using Microsoft.EntityFrameworkCore;
using MoviesIoasys.Domain.Entities;
using MoviesIoasys.Domain.Interfaces.Repositories;

namespace MoviesIoasys.Infra.Data.Sql.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly DataContext _context;
        private readonly DbSet<Movie> _movies;

        public MoviesRepository(
            DataContext context
        )
        {
            _context = context;
            _movies = _context.Set<Movie>();
        }

        public Movie Save(Movie movie)
        {
            _movies.Add(movie);
            _context.SaveChanges();

            return movie;
        }
    }
}
