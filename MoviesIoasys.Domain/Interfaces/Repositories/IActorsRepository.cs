using MoviesIoasys.Domain.Entities;

namespace MoviesIoasys.Domain.Interfaces.Repositories
{
    public interface IActorsRepository
    {
        Actor Save(Actor actor);
        Actor GetByActorByName(string name);
    }
}
