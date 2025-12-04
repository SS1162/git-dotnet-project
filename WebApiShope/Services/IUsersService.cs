using Entities;

namespace Services
{
    public interface IUsersService
    {
        Task<User> AddNewUsersService(User user);
        Task<User> GetByIDUsersService(int id);
        Task<User> LoginUsersService(LoginUser logInUser);
        void UpdateUsersService(int id, User value);
    }
}