using Entities;
using Repositories;
using DTO;
using AutoMapper;
namespace Services
{
    public class UsersService : IUsersService
    {//get by id
        private IRepositoriesUsers _irepositoriesUsers;
        private IMapper _Imapper;
        public UsersService(IRepositoriesUsers irepositoriesUsers, IMapper imapper)
        {
            this._irepositoriesUsers = irepositoriesUsers;
            this._Imapper = imapper;
        }
        public async Task<UserDTO> GetByIDUsersService(int id)
        {
            
            User user = await _irepositoriesUsers.GetByIDUsersRepositories(id);
            UserDTO userToController = _Imapper.Map<UserDTO>(user);
            return userToController;
        }
        //post new user
        public async Task<UserDTO> AddNewUsersService(RegisterUserDTO registerUser)
        {


            User userToReposetory = _Imapper.Map<User>(registerUser);
            bool flag = await _irepositoriesUsers.CheckIfUsersInsistalrady(userToReposetory);
            if (flag)
                return null;
            User userFromReposetory= await _irepositoriesUsers.AddNewUsersRepositories(userToReposetory);

            UserDTO userToController = _Imapper.Map<UserDTO>(userFromReposetory);
            return userToController;
        }

        //post login user
        public async Task<UserDTO> LoginUsersService(LoginUserDTO logInUser)
        {
            User userToRposetory = _Imapper.Map<User>(logInUser);


            User userFromRposetory= await _irepositoriesUsers.LoginUsersRepositories(userToRposetory);

            UserDTO userToConroller = _Imapper.Map<UserDTO>(userFromRposetory);

            return  userToConroller;
        }

         async public Task UpdateUsersService(int id, UpdateUserDTO userToUpdate)
        {


            User userToRposetory = _Imapper.Map<User>(userToUpdate);
            await _irepositoriesUsers.UpdateUsersRepositories(id, userToRposetory);
        }

    }
}
