using Microsoft.EntityFrameworkCore;
using MoviesIoasys.Domain.Entities;
using MoviesIoasys.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public Movie Get(Guid id)
            => _movies
                .Include(movie => movie.Category)
                .Include(movie => movie.Director)
                .Include(movie => movie.ActorMovies)
                .ThenInclude(movie => movie.Actor)
                .Include(movie => movie.Votes)
                .FirstOrDefault(movie => movie.Id == id);

        public IEnumerable<Movie> GetAll()
            => _movies
                   .Include(movie => movie.Category)
                   .Include(movie => movie.Director)
                   .Include(movie => movie.ActorMovies)
                   .ThenInclude(movie => movie.Actor)
                   .Include(movie => movie.Votes);

        public Movie Save(Movie movie)
        {
            _movies.Add(movie);
            _context.SaveChanges();

            return movie;
        }
    }
}
