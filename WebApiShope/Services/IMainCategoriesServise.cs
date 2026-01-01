using DTO;

namespace Services
{
    public interface IMainCategoriesServise
    {
        Task<MainCategoriesDTO> AddMainCategoriesServises(ManegerMainCategoryDTO manegerMainCategory);
        Task<Resulte<MainCategoriesDTO>> DeleteMainCategoriesServises(int id);
        Task<IEnumerable<MainCategoriesDTO>> GetMainCategoriesServises();
        Task<Resulte<MainCategoriesDTO>> UpdateMainCategoriesServises(int id, MainCategoriesDTO MainCategoriesFromController);
    }
}