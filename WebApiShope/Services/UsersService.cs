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
        public async Task<User> GetByIDUsersService(int id)
        {
            return await irepositoriesUsers.GetByIDUsersRepositories(id);
        }
        //post new user
        public async Task<User> AddNewUsersService(User user)
        {
            return await irepositoriesUsers.AddNewUsersRepositories(user);
        }

        //post login user
        public async Task<User> LoginUsersService(LoginUser logInUser)
        {
            return await irepositoriesUsers.LoginUsersRepositories(logInUser);
        }

        public void UpdateUsersService(int id, User value)
        {
            irepositoriesUsers.UpdateUsersRepositories(id, value);
        }

    }
}
