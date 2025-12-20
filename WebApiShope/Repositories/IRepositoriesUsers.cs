using Entities;

namespace Repositories
{
    public interface IRepositoriesUsers
    {
        Task<User> AddNewUsersRepositories(User user);
        Task<User?> GetByIDUsersRepositories(int id);
        Task<User?> LoginUsersRepositories(User LogInUser);
        Task UpdateUsersRepositories(int id, User user);
         Task<bool> CheckIfUsersInsistalrady(User user);
    }
}