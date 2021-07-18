using MoviesIoasys.Domain.Entities;

namespace MoviesIoasys.Domain.Interfaces.Repositories
{
    public interface IDirectorsRepository
    {
        Director Save(Director director);
        Director GetByDirectorByName(string name);
    }
}
