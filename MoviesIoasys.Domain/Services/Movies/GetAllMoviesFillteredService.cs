using MoviesIoasys.Domain.Entities;
using MoviesIoasys.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MoviesIoasys.Domain.Services.Movies
{
    public class GetAllMoviesFillteredService
    {
        private readonly IMoviesRepository _moviesRepository;

        public GetAllMoviesFillteredService(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public IEnumerable<Movie> GetAllMoviesFiltered(int page = 0, int size = 5, string director = "", string title = "", string category = "", string actor = "")
        {
            var movies = _moviesRepository.GetAll();

            foreach (var movie in movies)
                movie.CalculateRating();

            movies = movies.OrderByDescending(movie => movie.Rating).OrderBy(movie => movie.Title);

            if (page > 0)
                movies = movies.Skip((page - 1) * size).Take(size);

            if (FilterIsFilled(director))
                movies = movies.Where(movie => movie.Director.Name.Contains(director));

            if (FilterIsFilled(title))
                movies = movies.Where(movie => movie.Title.Contains(title));

            if (FilterIsFilled(category))
                movies = movies.Where(movie => movie.Category.Name.Contains(category));

            if (FilterIsFilled(actor))
                movies = movies.Where(movie => movie.ActorMovies.Any(actorMovie => actorMovie.Actor.Name.Contains(actor)));

            return movies;
        }

        private bool FilterIsFilled(string filter)
            => !string.IsNullOrEmpty(filter);
    }
}
