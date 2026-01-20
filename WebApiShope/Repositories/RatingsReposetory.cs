using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RatingsReposetory : IRatingsReposetory
    {

        MyShop330683525Context _DBContext;
        public RatingsReposetory(MyShop330683525Context DBContext)
        {
            this._DBContext = DBContext;
        }

        public async Task<Rating> AddRatingReposetory(Rating ratingToAdd)
        {
         
            await _DBContext.AddAsync(ratingToAdd);
            await _DBContext.SaveChangesAsync();
            return ratingToAdd;

        }

    }
}
