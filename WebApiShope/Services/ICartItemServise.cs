using DTO;

namespace Services
{
    public interface ICartItemServise
    {
        Task<Resulte<CartItemDTO?>> ChangeProductToNotValidCartServise(int cartItemId);
        Task<Resulte<CartItemDTO?>> ChangeProductToValidCartServise(int cartItemId);
      



        Task<Resulte<CartItemDTO?>> DeleteUserCartServise(int cartItemId);


        Task<Resulte<CartItemDTO>> CreateUserCartServise(AddToCartDTO dto);
        Task<CartItemDTO?> GetByIdServise(int id);


        Task<Resulte<IEnumerable<CartItemDTO>>> GetUserCartServise(int userId);
    }
}