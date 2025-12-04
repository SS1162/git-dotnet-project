using Entities;

namespace Repositories
{
    public interface IRepositoriesUsers
    {
        Task<User> AddNewUsersRepositories(User user);
        Task<User?> GetByIDUsersRepositories(int id);
        Task<User?> LoginUsersRepositories(LoginUser LogInUser);
        void UpdateUsersRepositories(int id, User user);
    }
}