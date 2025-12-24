using DTO;

namespace Services
{
    public interface IMainCategoriesServise
    {
        Task<MainCategoriesDTO> AddMainCategoriesServises(ManegerMainCategoryDTO manegerMainCategory);
        Task<bool> DeleteMainCategoriesServises(int id);
        Task<IEnumerable<MainCategoriesDTO>> GetMainCategoriesServises();
        Task UpdateMainCategoriesServises(int id, MainCategoriesDTO MainCategoriesFromController);
    }
}