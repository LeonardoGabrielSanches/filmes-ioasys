using MoviesIoasys.Domain.Entities;
using System;

namespace MoviesIoasys.Domain.DTOs.Movies
{
    public class CreateVoteForMovieDTO
    {
        public CreateVoteForMovieDTO(decimal value,
                                     Guid movieId)
        {
            Value = value;
            MovieId = movieId;
        }

        public decimal Value { get; set; }
        public Guid MovieId { get; set; }

        public static implicit operator Vote(CreateVoteForMovieDTO createVoteForMovieDTO)
            => new Vote(value: createVoteForMovieDTO.Value,
                        movieId: createVoteForMovieDTO.MovieId);
    }
}
