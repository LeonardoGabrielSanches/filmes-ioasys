using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MoviesIoasys.Domain.DTOs.Movies;

namespace MoviesIoasys.WebApi.ViewModels.Movies
{
    public class CreateMovieViewModel
    {
        [Required(ErrorMessage = "O campo título deve estar preenchido.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O campo descrição deve estar preenchido.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O campo diretor deve estar preenchido.")]
        public string Director { get; set; }

        [Required(ErrorMessage = "O campo atores deve estar preenchido.")]
        public IEnumerable<string> Cast { get; set; }

        [Required(ErrorMessage = "O campo gênero deve estar preenchido.")]
        public string Category { get; set; }

        public static implicit operator CreateMovieDTO(CreateMovieViewModel createMovieViewModel)
            => new CreateMovieDTO(title: createMovieViewModel.Title,
                                  description: createMovieViewModel.Description,
                                  director: createMovieViewModel.Director,
                                  cast: createMovieViewModel.Cast,
                                  category: createMovieViewModel.Category);
    }
}