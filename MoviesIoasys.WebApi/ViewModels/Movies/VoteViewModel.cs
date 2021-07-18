
using MoviesIoasys.Domain.Entities;
using System;

namespace MoviesIoasys.WebApi.ViewModels.Movies
{
    public class VoteViewModel
    {
        public decimal Value { get; set; }
        public Guid MovieId { get; set; }

        public static implicit operator VoteViewModel(Vote vote)
            => new VoteViewModel()
            {
                Value = vote.Value,
                MovieId = vote.MovieId
            };
    }
}
