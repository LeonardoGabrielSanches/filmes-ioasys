using System;
using MoviesIoasys.Domain.Entities;

namespace MoviesIoasys.WebApi.ViewModels.Movies
{
    public class MovieViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; private set; }

        public string Description { get; private set; }

        public static implicit operator MovieViewModel(Movie movie)
            => new MovieViewModel()
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description
            };
    }
}