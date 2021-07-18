using MoviesIoasys.Domain.Entities;
using MoviesIoasys.Domain.Interfaces.Repositories;
using System;

namespace MoviesIoasys.Domain.Services.Movies
{
    public class GetMovieDetailsService
    {
        private readonly IMoviesRepository _moviesRepository;

        public GetMovieDetailsService(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public Movie GetMovieDetails(Guid id)
        {
            var movie = _moviesRepository.Get(id);

            if (!movie?.Exists() ?? false)
                return movie;

            movie.CalculateRating();

            return movie;
        }
    }
}
