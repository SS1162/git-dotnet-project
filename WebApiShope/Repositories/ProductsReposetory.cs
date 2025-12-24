using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductsReposetory : IProductsReposetory
    {
        MyShop330683525Context _DBContext;
        public ProductsReposetory(MyShop330683525Context _DBContext)
        {
            this._DBContext = _DBContext;
        }

        async public Task<IEnumerable<Product>> GetProductsReposetory(int categoryID)
        {
            return await _DBContext.Products.Include(x => x.Category).Where(x=>x.CategoryId== categoryID).ToListAsync();
        }

        async public Task<Product> AddProductsReposetory(Product product)
        {
            await _DBContext.Products.AddAsync(product);
            await _DBContext.SaveChangesAsync();
            return product;
        }

        async public Task UpdateProductsReposetory(int id, Product product)
        {
            _DBContext.Products.Update(product);
            await _DBContext.SaveChangesAsync();
        }

        async public Task<bool> DeleteProductsReposetory(int id)
        {
            var productObjectToDelete = await _DBContext.Products.FirstOrDefaultAsync(x => x.ProductsId == id);



            var cartItem = await _DBContext.CartItems.FirstOrDefaultAsync(x => x.BasicSitesPlatforms == id);
            if (cartItem != null)
            {
                return false;
            }


            var oredersItem = await _DBContext.OrdersItems.FirstOrDefaultAsync(x => x.BasicSitesPlatforms == id);
            if (oredersItem != null)
            {
                return false;
            }
            if (productObjectToDelete == null)
            {
                return false;
            }
            _DBContext.Products.Remove(productObjectToDelete);
            await _DBContext.SaveChangesAsync();
            return true;
        }




    }
}
