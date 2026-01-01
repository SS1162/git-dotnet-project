using Entities;

namespace Repositories
{
    public interface ICartsReposetory
    {
        Task ChangeProductToNotValidReposetory(int Id);
        Task ChangeProductToValidReposetory(int Id);
        Task<CartItem> CreateUserCartReposetory(CartItem cartItem);
        Task DeleteUserCartItemReposetory(int Id);
        Task DeleteUserCartReposetory(int userID);
        Task<CartItem?> GetByIdReposetory(int id);
        Task<IEnumerable<CartItem>> GetByIDUserCartItemsReposetory(int Id);
        Task<CartItem?> GetByUserAndProductIdReposetory(int userId, int productId);

        Task<CartItem?> CheckIfHasPlatformByPlatformID(int Id);

        Task<CartItem?> CheckIfHasProductByProductID(int Id);

    }
}