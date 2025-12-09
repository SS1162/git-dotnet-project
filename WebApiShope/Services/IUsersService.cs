using Entities;

namespace Services
{
    public interface IUsersService
    {
        Task<User> AddUser(User user);
        Task<User> GetUserById(int id);
        Task<User> Login(LoginUser logInUser);
        Task UpdateUser(int id, User value);
    }
}