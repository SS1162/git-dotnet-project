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
        public CategoriesServise(ICategoriesReposetory _ICategoriesReposetory, IMapper _Imapper)
        {
            this._Imapper = _Imapper;
            this._ICategoriesReposetory = _ICategoriesReposetory;
        }

        async public Task<IEnumerable<CategoryDTO>> GetCategoriesServise(int paging, int limit, string? search, int? minPrice, int? MaxPrice, int? mainCategoryID)
        {

            List<Category> CategoryFromReposetory = (List<Category>)await _ICategoriesReposetory.GetCategoriesReposetory(paging, limit, search, minPrice, MaxPrice, mainCategoryID);
            return _Imapper.Map<List<CategoryDTO>>(CategoryFromReposetory);
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
