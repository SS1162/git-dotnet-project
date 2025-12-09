using Entities;

namespace Repositories
{
    public interface IProductsRepositoriy
    {
        Task<IEnumerable<Product>> ReturnProductRepositories(int[]? categoryID, int? minPrice, int? maxPrice, int? limit, int? paging);
    }
}