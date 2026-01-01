using Entities;

namespace Repositories
{
    public interface IMainCategoriesReposetory
    {
        Task<MainCategory> AddMainCategoriesReposetoty(MainCategory mainCategoryToAdd);
        Task DeleteMainCategoriesReposetoty( int id);
        Task<IEnumerable<MainCategory>> GetMainCategoriesReposetoty();
        Task UpdateMainCategoriesReposetoty(int id, MainCategory mainCategoryToUpdate);
        Task<MainCategory?> GetByIdMainCategoriesReposetoty(int id);
    }
}