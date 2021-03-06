using MoviesIoasys.Domain.DTOs.Movies;
using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesIoasys.WebApi.ViewModels.Movies
{
    public class CreateVoteForMovieViewModel
    {
        [Required(ErrorMessage = "O campo valor deve estar preenchido.")]
        [Range(0, 4, ErrorMessage = "O valor deve ser entre 0 e 4.")]
        public decimal Value { get; set; }

        public static CreateVoteForMovieDTO GetCreateVoteForMovieDTO(CreateVoteForMovieViewModel createVoteForMovieViewModel, Guid id)
            => new CreateVoteForMovieDTO(value: createVoteForMovieViewModel.Value,
                                         movieId: id);
    }
}
