using Microsoft.EntityFrameworkCore;
using MoviesIoasys.Domain.Entities;
using MoviesIoasys.Domain.Interfaces.Repositories;

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

        public Vote Save(Vote vote)
        {
            _votes.Add(vote);
            _context.SaveChanges();

            return vote;
        }
    }
}
