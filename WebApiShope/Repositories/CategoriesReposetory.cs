using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoriesReposetory : ICategoriesReposetory
    {
        MyShop330683525Context _DBContext;
        public CategoriesReposetory(MyShop330683525Context _DBContext)
        {
            this._DBContext = _DBContext;
        }
        async public Task<IEnumerable<Category>> GetCategoriesReposetory(int paging, int limit, string? search, int? minPrice, int? MaxPrice, int? mainCategoryID)
        {
            return await _DBContext.Categories.ToListAsync();
        }

        async public Task<Category?> GetByIDCategoriesReposetory(int id)
        {
            return await _DBContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);

        }

        async public Task UpdateCategoriesReposetory(int id, Category categoryToUpdate)
        {
            _DBContext.Categories.Update(categoryToUpdate);
            await _DBContext.SaveChangesAsync();

        }


        async public Task<Category> AddCategoriesReposetory(Category categoryToUpdate)
        {
            await _DBContext.Categories.AddAsync(categoryToUpdate);
            await _DBContext.SaveChangesAsync();
            return categoryToUpdate;

        }
        async public Task<bool> DeleteIDCategoriesReposetory(int id)
        {
            var Category = await _DBContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
           
            var listOfForginKeyObjects = await _DBContext.Products.Where(x => x.CategoryId == id).ToListAsync();
            if (listOfForginKeyObjects.Count == 0 &&Category!=null)
            {
                _DBContext.Categories.Remove(Category);
                await _DBContext.SaveChangesAsync();
                return true;
            }
            return false;

        }
    }
}
