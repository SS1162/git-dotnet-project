using DTO;

namespace Services
{
    public interface ICartItemServise
    {
        Task<CartItemDTO> CreateUserCartServise(AddToCartDTO dto);
        Task<bool> DeleteUserCartServise(int cartItemId);
        Task<CartItemDTO?> GetByIdServise(int id);
        Task<IEnumerable<CartItemDTO>?> GetUserCartServise(int userId);
        Task<CartItemDTO> UpdateUserCartServise(CartItemDTO dto);
    }
}