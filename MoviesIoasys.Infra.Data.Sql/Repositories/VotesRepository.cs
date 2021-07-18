using Microsoft.EntityFrameworkCore;
using MoviesIoasys.Domain.Entities;
using MoviesIoasys.Domain.Interfaces.Repositories;
using System;
using System.Linq;

namespace MoviesIoasys.Infra.Data.Sql.Repositories
{
    public class VotesRepository : IVotesRepository
    {
        private readonly DataContext _context;
        private readonly DbSet<Vote> _votes;

        public VotesRepository(DataContext context)
        {
            _context = context;
            _votes = _context.Set<Vote>();
        }

        public decimal GetMovieRating(Guid movieId)
        {
            var votes = _votes.AsNoTracking().Where(vote => vote.MovieId == movieId);
            decimal totalValue = votes.Sum(vote => vote.Value);
            int totalVotes = votes.Count();

            return totalValue / totalVotes;
        }

        public Vote Save(Vote vote)
        {
            _votes.Add(vote);
            _context.SaveChanges();

            return vote;
        }
    }
}
