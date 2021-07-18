using Microsoft.EntityFrameworkCore;
using MoviesIoasys.Domain.Entities;
using MoviesIoasys.Domain.Interfaces.Repositories;
using System.Linq;

namespace MoviesIoasys.Infra.Data.Sql.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly DataContext _context;
        private readonly DbSet<Category> _categories;

        public CategoriesRepository(
            DataContext context
        )
        {
            _context = context;
            _categories = _context.Set<Category>();
        }

        public Category GetByCategoryByName(string name)
            => _categories.AsNoTracking().FirstOrDefault(category => category.Name.ToUpper() == name.ToUpper());

        public Category Save(Category category)
        {
            _categories.Add(category);
            _context.SaveChanges();

            return category;
        }
    }
}
