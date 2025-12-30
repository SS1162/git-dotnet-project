using AutoMapper;
using DTO;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoriesServise : ICategoriesServise
    {
        ICategoriesReposetory _ICategoriesReposetory;
        IMapper _Imapper;
       IMainCategoriesReposetory _mainCategoriesReposetory;   
        public CategoriesServise(ICategoriesReposetory _ICategoriesReposetory, IMapper _Imapper ,
              IMainCategoriesReposetory mainCategoriesReposetory)
        {
            this._Imapper = _Imapper;
            this._ICategoriesReposetory = _ICategoriesReposetory;
            this._mainCategoriesReposetory = mainCategoriesReposetory;
        }

        async public Task<Resulte<ResponePage<CategoryDTO>>> GetCategoriesServise(int numberOfPages, int mainCategoryID, int pageSize, string? search)
        {
            MainCategory? checkIfMainCategoryInsist = await _mainCategoriesReposetory.GetByIdMainCategoriesReposetoty(mainCategoryID);
            if (checkIfMainCategoryInsist == null)
            {
                Resulte<ResponePage<CategoryDTO>>.Failure("Main category id isn't insist");
            }
            if (pageSize>50)
            {
                Resulte<ResponePage<CategoryDTO>>.Failure("The page Size is too big");
            }

            (IEnumerable<Category>,int) responeFromReposetory= await _ICategoriesReposetory.GetCategoriesReposetory( numberOfPages,  mainCategoryID, pageSize,  search);

            ResponePage<CategoryDTO> responeToClient = new ResponePage<CategoryDTO>();
            responeToClient.Data = _Imapper.Map<IEnumerable<CategoryDTO>>(responeFromReposetory.Item1);
            responeToClient.TotalItems= responeFromReposetory.Item2;
            responeToClient.CurrentPage = numberOfPages;
            responeToClient.PageSize = pageSize;
            responeToClient.HasPreviousPage = numberOfPages > 0;
            responeToClient.HasNextPage = (numberOfPages - 1) * pageSize > responeFromReposetory.Item2;


            return Resulte < ResponePage < CategoryDTO >> .Success(responeToClient);
        }

        async public Task<CategoryDTO> GetByIDCategoriesServise(int id)
        {
            Category CategoryFromReposetory = await _ICategoriesReposetory.GetByIDCategoriesReposetory(id);
            return _Imapper.Map<CategoryDTO>(CategoryFromReposetory);

        }

        async public Task UpdateCategoriesServise(int id, CategoryDTO categoryToUpdate)
        {
            Category categoryToReposetory = _Imapper.Map<Category>(categoryToUpdate);
            //למלא פרומפט עם gemini
            categoryToReposetory.CategoryPrompt = "vfsghhfg";
            await _ICategoriesReposetory.UpdateCategoriesReposetory(id, categoryToReposetory);

        }


        async public Task<CategoryDTO> AddCategoriesServise(AddCategoryDTO categoryToUpdate)
        {
            Category categoryToReposetory = _Imapper.Map<Category>(categoryToUpdate);
            //למלא פרומפט עם gemini
            categoryToReposetory.CategoryPrompt = "gfasdfghfh";
            Category categoryFromReposetory = await _ICategoriesReposetory.AddCategoriesReposetory(categoryToReposetory);

            return _Imapper.Map<CategoryDTO>(categoryFromReposetory);
        }
        async public Task<bool> DeleteIDCategoriesServise(int id)
        {
           
            return await _ICategoriesReposetory.DeleteIDCategoriesReposetory(id);
        }

    }
}
