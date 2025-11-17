using Entities;

namespace Repositories
{
    public interface IRepositoriesUsers
    {
        Users AddNewUsersRepositories(Users user);
        Users GetByIDUsersRepositories(int id);
        LoginUser LoginUsersRepositories(LoginUser LogInUser);
        void UpdateUsersRepositories(int id, Users value);
    }
}