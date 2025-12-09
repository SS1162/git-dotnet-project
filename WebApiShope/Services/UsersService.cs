using Entities;
using Repositories;
namespace Services
{
    public class UsersService : IUsersService
    {//get by id
        private readonly IRepositoriesUsers _repositoriesUsers;
        public UsersService(IRepositoriesUsers repositoriesUsers)
        {
            _repositoriesUsers = repositoriesUsers;
        }
        public async Task<User> GetUserById(int id)
        {
            return await _repositoriesUsers.GetUserById(id);
        }
        //post new user
        public async Task<User> AddUser(User user)
        {
            return await _repositoriesUsers.AddUser(user);
        }

        //post login user
        public async Task<User> Login(LoginUser logInUser)
        {
            return await _repositoriesUsers.Login(logInUser);
        }

        public async Task UpdateUser(int id, User value)
        {
            await _repositoriesUsers.UpdateUser(id, value);
        }

    }
}
