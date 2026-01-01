using Entities;

namespace Repositories
{
    public interface IReviewsReposetory
    {
        Task<Review> AddReviewReposetory(Review review);
        Task<Review> GetReviewByOrderIdReposetory(int orderId);
        Task UpdateReviewReposetory(int id ,Review review);
        Task<Review?> GetByidReviewReposetory(int id);
    }
}