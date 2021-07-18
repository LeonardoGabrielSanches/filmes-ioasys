using MoviesIoasys.Domain.DTOs.Movies;
using MoviesIoasys.Domain.Entities;
using MoviesIoasys.Domain.Interfaces.Repositories;

namespace MoviesIoasys.Domain.Services.Movies
{
    public class CreateVoteForMovieService
    {
        private readonly IVotesRepository _votesRepository;
        private readonly IMoviesRepository _moviesRepository;

        public CreateVoteForMovieService(IVotesRepository votesRepository,
                                         IMoviesRepository moviesRepository)
        {
            _votesRepository = votesRepository;
            _moviesRepository = moviesRepository;
        }

        public Vote CreateVoteForMovie(CreateVoteForMovieDTO createVoteForMovieDTO)
        {
            var vote = (Vote)createVoteForMovieDTO;

            if (!vote.IsValid)
                return vote;

            var movie = _moviesRepository.Get(vote.MovieId);

            if (!movie?.Exists() ?? false)
                return new Vote().GetInvalidVote("Filme não encontrado.");

            _votesRepository.Save(vote);

            return vote;
        }
    }
}
