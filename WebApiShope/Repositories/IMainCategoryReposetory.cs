using Entities;

namespace Repositories
{
    public interface IMainCategoryReposetory
    {
        Task<MainCategory> AddMainCategoriesReposetoty(MainCategory mainCategoryToAdd);
        Task<bool> DeleteMainCategoriesReposetoty( int id);
        Task<IEnumerable<MainCategory>> GetMainCategoriesReposetoty();
        Task UpdateMainCategoriesReposetoty(int id, MainCategory mainCategoryToUpdate);
    }
}