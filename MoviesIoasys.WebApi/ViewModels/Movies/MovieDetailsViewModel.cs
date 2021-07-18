using MoviesIoasys.Domain.Entities;
using MoviesIoasys.WebApi.ViewModels.Actors;
using MoviesIoasys.WebApi.ViewModels.Categories;
using MoviesIoasys.WebApi.ViewModels.Directors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesIoasys.WebApi.ViewModels.Movies
{
    public class MovieDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DirectorViewModel Director { get; set; }
        public CategoryViewModel Category { get; set; }
        public IEnumerable<ActorViewModel> Cast { get; set; }
        public decimal Rating { get; set; }

        public static implicit operator MovieDetailsViewModel(Movie movie)
            => new MovieDetailsViewModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Director = movie.Director,
                Category = movie.Category,
                Cast = movie.ActorMovies.Select(x => (ActorViewModel)x.Actor),
                Rating = movie.Rating
            };
    }
}
