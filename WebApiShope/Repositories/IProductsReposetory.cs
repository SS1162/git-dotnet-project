using Entities;

namespace Repositories
{
    public interface IProductsReposetory
    {
        Task<Product> AddProductsReposetory(Product product);
        Task<bool> DeleteProductsReposetory(int id);
        Task<IEnumerable<Product>> GetProductsReposetory(int categoryID);
        Task UpdateProductsReposetory(int id, Product product);
    }
}