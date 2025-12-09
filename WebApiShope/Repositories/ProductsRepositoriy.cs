using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductsRepositoriy : IProductsRepositoriy
    {

        MyShop330683525Context _MyShop330683525Context;

        public ProductsRepositoriy(MyShop330683525Context _MyShop330683525Context)
        {
            this._MyShop330683525Context = _MyShop330683525Context;
        }


        async public Task<IEnumerable<Product>> ReturnProductRepositories(int[]? categoryID, int? minPrice, int? maxPrice, int? limit, int? paging)
        {
            return await _MyShop330683525Context.Products.ToListAsync();
        }

    }
}
