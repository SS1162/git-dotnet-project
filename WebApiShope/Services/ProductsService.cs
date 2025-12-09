using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductsService : IProductsService
    {



        private IProductsRepositoriy iproductsRepositoriy;
        public ProductsService(IProductsRepositoriy iproductsRepositoriy)
        {
            this.iproductsRepositoriy = iproductsRepositoriy;
        }

        public async Task<IEnumerable<Product>> ReturnProductService(int[]? categoryID, int? minPrice, int? maxPrice, int? limit, int? paging)
        {
            return await iproductsRepositoriy.ReturnProductRepositories(categoryID, minPrice,maxPrice, limit, paging);
        }


    }
}
