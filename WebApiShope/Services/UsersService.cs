using Entities;
using Repositories;
namespace Services
{
    public class UsersService : IUsersService
    {//get by id
        private IRepositoriesUsers irepositoriesUsers;
        public UsersService(IRepositoriesUsers irepositoriesUsers)
        {
            this.irepositoriesUsers = irepositoriesUsers;
        }
        public Users GetByIDUsersService(int id)
        {
            return irepositoriesUsers.GetByIDUsersRepositories(id);
        }
        //post new user
        public Users AddNewUsersService(Users user)
        {
            return irepositoriesUsers.AddNewUsersRepositories(user);
        }

        //post login user
        public LoginUser LoginUsersService(LoginUser logInUser)
        {
            return irepositoriesUsers.LoginUsersRepositories(logInUser);
        }

        public void UpdateUsersService(int id, Users value)
        {
            irepositoriesUsers.UpdateUsersRepositories(id, value);
        }

    }
}
