using AutoMapper;
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
    public class ReviewsServise : IReviewsServise
    {
        IReviewsReposetory _ReviewsReposetory;
        IMapper _mapper;


        public ReviewsServise(IReviewsReposetory _ReviewsReposetory, IMapper _mapper)
        {
            this._ReviewsReposetory = _ReviewsReposetory;
            this._mapper = _mapper;
        }
        public async Task<ReviewDTO> AddReviewServise(int orderId, AddReviewDTO review)
        {
            Review existingReview = await _ReviewsReposetory.GetReviewByOrderIdReposetory(orderId);
            if (existingReview != null)
            {
                return null;
            }
            Review reviewToReposetory = _mapper.Map<Review>(review);
            Review reviewFromReposetory = await _ReviewsReposetory.AddReviewReposetory(reviewToReposetory);
            return _mapper.Map<ReviewDTO>(reviewFromReposetory);
        }

        public async Task<ReviewDTO> GetReviewByOrderIdServise(int orderId)
        {
            Review review = await _ReviewsReposetory.GetReviewByOrderIdReposetory(orderId);

            return _mapper.Map<ReviewDTO>(review);
        }
        public async Task UpdateReviewServise(int id, ReviewDTO review)
        {
            Review reviewToReposetory = _mapper.Map<Review>(review);
            await _ReviewsReposetory.UpdateReviewReposetory(id, reviewToReposetory);
        }
    }
}
