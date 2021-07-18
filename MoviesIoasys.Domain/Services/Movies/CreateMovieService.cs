using MoviesIoasys.Domain.DTOs.Movies;
using MoviesIoasys.Domain.Entities;
using MoviesIoasys.Domain.Interfaces.Repositories;

namespace MoviesIoasys.Domain.Services.Movies
{
    public class CreateMovieService
    {
        private readonly IMoviesRepository _moviesRepository;

        public CreateMovieService(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public Movie CreateMovie(CreateMovieDTO createMovieDTO)
        {
            var movie = (Movie)createMovieDTO;

            if (!movie.IsValid)
                return new Movie().GetInvalidMovie(movie.NotificationError);

            _moviesRepository.Save(movie);

            return movie;
        }
    }
}