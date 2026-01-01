using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
namespace Repositories
{
    public class MainCategoriesReposetory : IMainCategoriesReposetory
    {
        MyShop330683525Context _DBContext;
        public MainCategoriesReposetory(MyShop330683525Context _DBContext)
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
            await _DBContext.SaveChangesAsync();
            return mainCategoryToAdd;
        }




        async public Task UpdateMainCategoriesReposetoty(int id, MainCategory mainCategoryToUpdate)
        {

            _DBContext.MainCategories.Update(mainCategoryToUpdate);
            await _DBContext.SaveChangesAsync();

        }


        async public Task<MainCategory?> GetByIdMainCategoriesReposetoty(int id)
        {
            return await _DBContext.MainCategories.FirstOrDefaultAsync(x => x.MainCategoryId == id);
        }



        //עדיין אין בדיקות
        async public Task DeleteMainCategoriesReposetoty(int id)
        {
            MainCategory mainCategory = await _DBContext.MainCategories.FirstOrDefaultAsync(x=>x.MainCategoryId==id);
            _DBContext.Remove(mainCategory);
            await _DBContext.SaveChangesAsync();
        }




    }
}
