using DTO;

namespace Services
{
    public interface ICategoriesServise
    {
        Task<CategoryDTO> AddCategoriesServise(AddCategoryDTO categoryToUpdate);
        Task<bool> DeleteIDCategoriesServise(int id);
        Task<CategoryDTO> GetByIDCategoriesServise(int id);
        Task<IEnumerable<CategoryDTO>> GetCategoriesServise(int paging, int limit, string? search, int? minPrice, int? MaxPrice, int? mainCategoryID);
        Task UpdateCategoriesServise(int id, CategoryDTO categoryToUpdate);
    }
}