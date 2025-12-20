using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
namespace Repositories
{
    public class MainCategoryReposetory : IMainCategoryReposetory
    {
        MyShop330683525Context _DBContext;
        public MainCategoryReposetory(MyShop330683525Context _DBContext)
        {
            this._DBContext = _DBContext;
        }
        async public Task<IEnumerable<MainCategory>> GetMainCategoriesReposetoty()
        {
            return await _DBContext.MainCategories.ToListAsync();
        }


        async public Task<MainCategory> AddMainCategoriesReposetoty(MainCategory mainCategoryToAdd)
        {

            await _DBContext.MainCategories.AddAsync(mainCategoryToAdd);
            _DBContext.SaveChangesAsync();
            return mainCategoryToAdd;
        }




        async public Task UpdateMainCategoriesReposetoty(int id, MainCategory mainCategoryToUpdate)
        {

            _DBContext.MainCategories.Update(mainCategoryToUpdate);
            await _DBContext.SaveChangesAsync();

        }


        async public Task<Boolean> DeleteMainCategoriesReposetoty( int id)
        {
            var mainCategory = await _DBContext.MainCategories.FirstOrDefaultAsync(x=>x.MainCategoryId==id);
            var listOfForginKeyObjects = await _DBContext.Categories.Where(x => x.MainCategoryId == id).ToListAsync();
            if (listOfForginKeyObjects.Count==0 && mainCategory != null)
            {
                _DBContext.MainCategories.Remove(mainCategory);
                await _DBContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
