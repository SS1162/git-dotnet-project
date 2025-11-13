using Entities;
using Repositories;
namespace Services
{
    public class UsersService
    {//get by id
        private RepositoriesUsers repositoriesUsers = new RepositoriesUsers();
        public Users GetByIDUsersService(int id)
        {
            return repositoriesUsers.GetByIDUsersRepositories(id);
        }
        //post new user
        public Users AddNewUsersService(Users user)
        {
            return repositoriesUsers.AddNewUsersRepositories(user);
        }

        //post login user
        public LoginUser LoginUsersService(LoginUser logInUser)
        {
            return repositoriesUsers.LoginUsersRepositories(logInUser);
        }

        public void UpdateUsersService(int id, Users value)
        {
            repositoriesUsers.UpdateUsersRepositories(id,value);
        }

    }
}
