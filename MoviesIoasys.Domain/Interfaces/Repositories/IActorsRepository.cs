using MoviesIoasys.Domain.Entities;

namespace MoviesIoasys.Domain.Interfaces.Repositories
{
    public interface IActorsRepository
    {
        Actor Save(Actor actor);
        Actor GetActorByName(string name);
    }
}
