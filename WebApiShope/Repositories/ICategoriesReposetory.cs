using Entities;

namespace Repositories
{
    public interface ICategoriesReposetory
    {
        Task<Category> AddCategoriesReposetory(Category categoryToUpdate);
        Task<bool> DeleteIDCategoriesReposetory(int id);
        Task<Category?> GetByIDCategoriesReposetory(int id);
        Task<IEnumerable<Category>> GetCategoriesReposetory(int paging, int limit, string? search, int? minPrice, int? MaxPrice, int? mainCategoryID);
        Task UpdateCategoriesReposetory(int id, Category categoryToUpdate);
    }
}