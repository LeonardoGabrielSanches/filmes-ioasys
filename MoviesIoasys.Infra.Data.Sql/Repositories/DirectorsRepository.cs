using Microsoft.EntityFrameworkCore;
using MoviesIoasys.Domain.Entities;
using MoviesIoasys.Domain.Interfaces.Repositories;
using System.Linq;

namespace MoviesIoasys.Infra.Data.Sql.Repositories
{
    public class DirectorsRepository : IDirectorsRepository
    {
        private readonly DataContext _context;
        private readonly DbSet<Director> _directors;

        public DirectorsRepository(
            DataContext context
        )
        {
            _context = context;
            _directors = _context.Set<Director>();
        }

        public Director GetByDirectorByName(string name)
            => _directors.AsNoTracking().FirstOrDefault(director => director.Name.ToUpper() == name.ToUpper());

        public Director Save(Director director)
        {
            _directors.Add(director);
            _context.SaveChanges();

            return director;
        }
    }
}
