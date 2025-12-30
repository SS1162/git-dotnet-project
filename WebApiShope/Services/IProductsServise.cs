using DTO;

namespace Services
{
    public interface IProductsServise
    {
        Task<ProductDTO> AddProductServise(AddProductDTO productToUpdate);
        Task<bool> DeleteIDProductServise(int id);
        Task<Resulte<ResponePage<ProductDTO>>> GetProductsServise(int categoryID, int numOfPages, int PageSize, string? search, int? minPrice, int? MaxPrice, bool? orderByPrice, bool? desc);
        Task UpdateProductServise(int id, UpdateProductDTO productToUpdate);
    }
}