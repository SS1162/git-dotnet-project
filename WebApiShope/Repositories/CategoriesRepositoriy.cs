using Entities;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoriesRepositoriy : ICategoriesRepositoriy
    {
        MyShop330683525Context _MyShop330683525Context;

        public CategoriesRepositoriy(MyShop330683525Context _MyShop330683525Context)
        {
            this._MyShop330683525Context = _MyShop330683525Context;
        }


        async public Task<IEnumerable<Category>> ReturnCategoryRepositories()
        {
            return await _MyShop330683525Context.Categories.ToListAsync();
        }


    }
}
