using Entities;

namespace Repositories
{
    public interface IProductsReposetory
    {
        Task<Product> AddProductsReposetory(Product product);
        Task<bool> DeleteProductsReposetory(int id);
        Task<(IEnumerable<Product> items, int totalCount)> GetProductsReposetory(int categoryID, int numOfPages, int PageSize, string? search, int? minPrice, int? MaxPrice, bool? orderByPrice, bool? desc);
        Task UpdateProductsReposetory(int id, Product product);
    }
}