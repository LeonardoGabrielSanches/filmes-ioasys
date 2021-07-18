using MoviesIoasys.Domain.Entities;

namespace MoviesIoasys.Domain.Interfaces.Repositories
{
    public interface IVotesRepository
    {
        Vote Save(Vote vote);
    }
}
