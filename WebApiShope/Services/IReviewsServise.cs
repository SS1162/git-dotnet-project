using DTO;

namespace Services
{
    public interface IReviewsServise
    {
        Task<Resulte<ReviewDTO>> AddReviewServise(int orderId, AddReviewDTO review);
        Task<Resulte<ReviewDTO>> GetReviewByOrderIdServise(int orderId);
        Task<Resulte<ReviewDTO>> UpdateReviewServise(int id, ReviewDTO review);
    }
}