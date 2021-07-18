using System.Collections.Generic;
using System.Linq;
using MoviesIoasys.Domain.Entities;
using MoviesIoasys.WebApi.ViewModels.Actors;
using MoviesIoasys.WebApi.ViewModels.Categories;
using MoviesIoasys.WebApi.ViewModels.Directors;

namespace MoviesIoasys.WebApi.ViewModels.Movies
{
    public class MovieViewModel
    {
        public string Title { get; private set; }

        public string Description { get; private set; }

        public DirectorViewModel Director { get; private set; }

        public IEnumerable<ActorViewModel> Cast { get; private set; }

        public CategoryViewModel Category { get; private set; }

        public static implicit operator MovieViewModel(Movie movie)
            => new MovieViewModel()
            {
                Title = movie.Title,
                Description = movie.Description,
                Director = movie.Director,
                Cast = movie.Cast.Select(actor => (ActorViewModel)actor),
                Category = movie.Category
            };
    }
}