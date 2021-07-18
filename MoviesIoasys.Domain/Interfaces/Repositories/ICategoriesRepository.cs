using MoviesIoasys.Domain.Entities;

namespace MoviesIoasys.Domain.Interfaces.Repositories
{
    public interface ICategoriesRepository
    {
        Category Save(Category category);
        Category GetByCategoryByName(string name);
    }
}
