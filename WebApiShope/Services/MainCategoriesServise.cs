using DTO;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using AutoMapper;
namespace Services
{
    public class MainCategoriesServise :IMainCategoriesServise
    {

        IMainCategoriesReposetory _IMainCategoryReposetory;
        IMapper _Imapper;
        public MainCategoriesServise(IMainCategoriesReposetory _IMainCategoryReposetory, IMapper _Imapper)
        {
            this._IMainCategoryReposetory = _IMainCategoryReposetory;
            this._Imapper = _Imapper;
        }
        async public Task<IEnumerable<MainCategoriesDTO>> GetMainCategoriesServises()
        {
           List<MainCategory> MainCategoriesListFromReposetory = (List<MainCategory>)await _IMainCategoryReposetory.GetMainCategoriesReposetoty();

            List<MainCategoriesDTO> MainCategoriesListToController = _Imapper.Map<List<MainCategoriesDTO>>(MainCategoriesListFromReposetory);
            return MainCategoriesListToController;

        }


        async public Task<MainCategoriesDTO> AddMainCategoriesServises(ManegerMainCategoryDTO manegerMainCategory)
        {
            MainCategory mainCategoryToReposetory = _Imapper.Map<MainCategory>(manegerMainCategory);
            //הכנסה של פרומפט ע"י gemini
        

            MainCategory mainCategoryFromeposetory = await _IMainCategoryReposetory.AddMainCategoriesReposetoty(mainCategoryToReposetory);
            return _Imapper.Map<MainCategoriesDTO>(mainCategoryFromeposetory);
        }

        async public Task UpdateMainCategoriesServises(int id, MainCategoriesDTO MainCategoriesFromController)
        {

            MainCategory mainCategoryToReposetory = _Imapper.Map<MainCategory>(MainCategoriesFromController);
            //הכנסה של פרומפט ע"י gemini
            
            await _IMainCategoryReposetory.UpdateMainCategoriesReposetoty(id, mainCategoryToReposetory);
        }

        async public Task<bool> DeleteMainCategoriesServises(int id)
        {


            return await _IMainCategoryReposetory.DeleteMainCategoriesReposetoty(id);    
        }
    }
}
