using DTO;

namespace Services
{
    public interface IProductsServise
    {
        Task<ProductDTO> AddProductServise(AddProductDTO productToUpdate);
        Task<bool> DeleteIDProductServise(int id);
        Task<IEnumerable<ProductDTO>> GetProductsServise(int categoryID);
        Task UpdateProductServise(int id, UpdateProductDTO productToUpdate);
    }
}