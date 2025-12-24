using DTO;

namespace Services
{
    public interface IReviewsServise
    {
        Task<ReviewDTO> AddReviewServise(int orderId, AddReviewDTO review);
        Task<ReviewDTO> GetReviewByOrderIdServise(int orderId);
        Task UpdateReviewServise(int id, ReviewDTO review);
    }
}