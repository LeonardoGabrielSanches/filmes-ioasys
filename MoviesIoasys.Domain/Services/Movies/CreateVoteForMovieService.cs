using MoviesIoasys.Domain.DTOs.Movies;
using MoviesIoasys.Domain.Entities;
using MoviesIoasys.Domain.Interfaces.Repositories;

namespace MoviesIoasys.Domain.Services.Movies
{
    public class CreateVoteForMovieService
    {
        private readonly IVotesRepository _votesRepository;

        public CreateVoteForMovieService(IVotesRepository votesRepository)
        {
            _votesRepository = votesRepository;
        }

        public Vote CreateVoteForMovie(CreateVoteForMovieDTO createVoteForMovieDTO)
        {
            var vote = (Vote)createVoteForMovieDTO;

            if (!vote.IsValid)
                return vote;

            _votesRepository.Save(vote);

            return vote;
        }
    }
}
