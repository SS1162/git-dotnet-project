using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;
namespace Services
{


    public class CategoriesService : ICategoriesService
    {


        private ICategoriesRepositoriy icategoriesRepositoriy;
        public CategoriesService(ICategoriesRepositoriy icategoriesRepositoriy)
        {
            this.icategoriesRepositoriy = icategoriesRepositoriy;
        }

        public async Task<IEnumerable<Category>> ReturnCategoryService()
        {
            return await icategoriesRepositoriy.ReturnCategoryRepositories();
        }



    }
}
