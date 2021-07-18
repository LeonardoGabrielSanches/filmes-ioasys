using Microsoft.EntityFrameworkCore;
using MoviesIoasys.Domain.Entities;
using MoviesIoasys.Domain.Interfaces.Repositories;
using System.Linq;

namespace MoviesIoasys.Infra.Data.Sql.Repositories
{
    public class ActorsRepository : IActorsRepository
    {
        private readonly DataContext _context;
        private readonly DbSet<Actor> _actors;

        public ActorsRepository(
            DataContext context
        )
        {
            _context = context;
            _actors = _context.Set<Actor>();
        }

        public Actor GetByActorByName(string name)
            => _actors.AsNoTracking().FirstOrDefault(actor => actor.Name.ToUpper() == name.ToUpper());

        public Actor Save(Actor actor)
        {
            _actors.Add(actor);
            _context.SaveChanges();

            return actor;
        }
    }
}
