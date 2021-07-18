using System;
using MoviesIoasys.Domain.Entities;

namespace MoviesIoasys.WebApi.ViewModels.Movies
{
    public class MovieViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public static implicit operator MovieViewModel(Movie movie)
            => new MovieViewModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description
            };
    }
}