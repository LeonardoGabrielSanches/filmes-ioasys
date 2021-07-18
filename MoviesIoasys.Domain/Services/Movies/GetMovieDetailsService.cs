using MoviesIoasys.Domain.Entities;
using MoviesIoasys.Domain.Interfaces.Repositories;
using System;

namespace MoviesIoasys.Domain.Services.Movies
{
    public class GetMovieDetailsService
    {
        private readonly IMoviesRepository _moviesRepository;
        private readonly IVotesRepository _votesRepository;

        public GetMovieDetailsService(IMoviesRepository moviesRepository,
                                      IVotesRepository votesRepository)
        {
            _moviesRepository = moviesRepository;
            _votesRepository = votesRepository;
        }

        public Movie GetMovieDetails(Guid id)
        {
            var movie = _moviesRepository.Get(id);

            if (!movie?.Exists() ?? false)
                return movie;

            var rating = _votesRepository.GetMovieRating(id);

            movie.SetRating(rating);

            return movie;
        }
    }
}
