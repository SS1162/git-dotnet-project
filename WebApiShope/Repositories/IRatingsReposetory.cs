using Entities;

namespace Repositories
{
    public interface IRatingsReposetory
    {
        Task<Rating> AddRatingReposetory(Rating ratingToAdd);
    }
}