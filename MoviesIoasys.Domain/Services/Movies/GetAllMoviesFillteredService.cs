using MoviesIoasys.Domain.Entities;
using MoviesIoasys.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MoviesIoasys.Domain.Services.Movies
{
    public class GetAllMoviesFillteredService
    {
        private readonly IMoviesRepository _moviesRepository;

        public IEnumerable<Movie> GetAllMoviesFiltered(List<string> actors, int page = 0, int size = 5, string director = "", string title = "", string category = "")
        {
            var movies = _moviesRepository.GetAll();

            foreach (var movie in movies)
                movie.CalculateRating();

            movies = movies.OrderBy(movie => movie.Rating).ThenBy(movie => movie.Title);

            if (page > 0)
                movies = movies.Skip((page - 1) * size).Take(size);

            if (FilterIsFilled(director))
                movies = movies.Where(movie => movie.Director.Name.Contains(director));

            if (FilterIsFilled(title))
                movies = movies.Where(movie => movie.Title.Contains(title));

            if (FilterIsFilled(category))
                movies = movies.Where(movie => movie.Category.Name.Contains(category));

            if (FilterIsFilled(actors))
                movies = movies.Where(movie=>movie.ActorMovies.Contains())

                return movies;
        }

        private bool FilterIsFilled(string filter)
            => !string.IsNullOrEmpty(filter);

        private bool FilterIsFilled(List<string> actors)
            => actors?.Any() ?? false;
    }
}
