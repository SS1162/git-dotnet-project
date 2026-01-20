using Entities;

namespace Services
{
    public interface IRatingsServise
    {
        Task<Rating> AddRatingServise(Rating ratingToAdd);
    }
}