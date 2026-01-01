using DTO;

namespace Services
{
    public interface IProductsServise
    {
        Task<Resulte<ProductDTO>> AddProductServise(AddProductDTO productToUpdate);
        Task<Resulte<ProductDTO>> DeleteIDProductServise(int id);
        Task<Resulte<ResponePage<ProductDTO>>> GetProductsServise(int categoryID, int numOfPages, int PageSize, string? search, int? minPrice, int? MaxPrice, bool? orderByPrice, bool? desc);
        Task<Resulte<ProductDTO>> UpdateProductServise(int id, UpdateProductDTO productToUpdate);
    }
}