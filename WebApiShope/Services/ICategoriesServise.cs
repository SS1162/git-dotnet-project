using DTO;

namespace Services
{
    public interface ICategoriesServise
    {
        Task<CategoryDTO> AddCategoriesServise(AddCategoryDTO categoryToUpdate);
        Task<bool> DeleteIDCategoriesServise(int id);
        Task<CategoryDTO> GetByIDCategoriesServise(int id);
        Task<Resulte<ResponePage<CategoryDTO>>> GetCategoriesServise(int numberOfPages, int mainCategoryID, int pageSize, string? search);
        Task UpdateCategoriesServise(int id, CategoryDTO categoryToUpdate);
    }
}