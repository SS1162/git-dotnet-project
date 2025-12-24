using Entities;

namespace Repositories
{
    public interface ICartsReposetory
    {
        Task ChangeProductToNotValidReposetory(int Id, CartItem cartItem);
        Task ChangeProductToValidReposetory(int Id, CartItem cartItem);
        Task<CartItem> CreateUserCartReposetory(CartItem cartItem);
        Task<bool> DeleteUserCartReposetory(int Id);
        Task<CartItem?> GetByIdReposetory(int id);
        Task<IEnumerable<CartItem>> GetByIDUserCartItemsReposetory(int Id);
        Task<CartItem?> GetByUserAndProductIdReposetory(int userId, int productId);
        Task UpdateUserCartReposetory(CartItem cartItem);
        Task DeleteUserCartReposetory(List<CartItem> cartList);
    }
}