using DTO;

namespace Services
{
    public interface ICategoriesServise
    {
        Task<Resulte<CategoryDTO>> AddCategoriesServise(AddCategoryDTO categoryToAdd);
        Task<Resulte<CategoryDTO>> DeleteIDCategoriesServise(int id);
        Task<CategoryDTO> GetByIDCategoriesServise(int id);
        Task<Resulte<ResponePage<CategoryDTO>>> GetCategoriesServise(int numberOfPages, int mainCategoryID, int pageSize, string? search);
        Task<Resulte<CategoryDTO?>> UpdateCategoriesServise(int id, CategoryToUpdateDTO categoryToUpdate);
    }
}