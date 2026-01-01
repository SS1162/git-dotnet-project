using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ReviewsReposetory : IReviewsReposetory
    {


        MyShop330683525Context _DBcontext;

        public ReviewsReposetory(MyShop330683525Context _DBcontext)
        {
            this._DBcontext = _DBcontext;
        }


        public async Task<Review> AddReviewReposetory(Review review)
        {
            _DBcontext.Reviews.Add(review);
            await _DBcontext.SaveChangesAsync();
            return review;
        }


        public async Task<Review?> GetByidReviewReposetory(int id)
        {
            return await _DBcontext.Reviews.FirstOrDefaultAsync(x => x.ReviewId == id);
        }

        public async Task<Review> GetReviewByOrderIdReposetory(int orderId)
        {
            Order orderForReviews = await _DBcontext.Orders.FirstOrDefaultAsync(r => r.OrderId == orderId);
                return await _DBcontext.Reviews.FirstOrDefaultAsync(r => r.ReviewId == orderForReviews.ReviewId);
         
        }

        public async Task UpdateReviewReposetory(int id ,Review review)
        {
            _DBcontext.Reviews.Update(review);
            await _DBcontext.SaveChangesAsync();
            
        }
    }
}
