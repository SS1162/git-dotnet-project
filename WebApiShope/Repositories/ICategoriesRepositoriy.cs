using Entities;

namespace Repositories
{
    public interface ICategoriesRepositoriy
    {
        Task<IEnumerable<Category>> ReturnCategoryRepositories();
    }
}