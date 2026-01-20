using DTO;
using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class GeminiServise : IGeminiServise
    {
        Igemini _gemini;
        ICategoriesReposetory _categoriesReposetory;
        public GeminiServise(Igemini gemini, ICategoriesReposetory categoriesReposetory)
        {
            this._gemini = gemini;
            this._categoriesReposetory = categoriesReposetory;
        }

        public async Task<Resulte<string>> getGeminiForUserProductServise(int id, string userRequest)
        {
            Category? coategort = await _categoriesReposetory.GetByIDCategoriesReposetory(id);
            if (coategort == null)
            {
                Resulte<string>.Failure("The product id is incorect");
            }
            string resulte = await _gemini.RunGeminiForUserProduct(userRequest, coategort.CategoryName);
            return Resulte<string>.Success(resulte);
        }
    }
}
