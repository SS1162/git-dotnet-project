using Entities;

namespace Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> ReturnProductService(int[]? categoryID, int? minPrice, int? maxPrice, int? limit, int? paging);
    }
}