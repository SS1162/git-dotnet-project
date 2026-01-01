using Entities;
using Repositories;
using DTO;
using AutoMapper;
namespace Services
{
    public class UsersService : IUsersService
    {//get by id
        private IUsersReposetory _UsersReposetory;
        private IMapper _Imapper;
        public UsersService(IUsersReposetory irepositoriesUsers, IMapper imapper)
        {
            this._UsersReposetory = irepositoriesUsers;
            this._Imapper = imapper;
        }
        public async Task<UserDTO> GetByIDUsersService(int id)
        {
            
            User? user = await _UsersReposetory.GetByIDUsersRepositories(id);
            UserDTO userToController = _Imapper.Map<UserDTO>(user);
            return userToController;
        }
        //post new user
        public async Task<UserDTO?> AddNewUsersService(RegisterUserDTO registerUser)
        {

            User userToReposetory = _Imapper.Map<User>(registerUser);
            bool flag = await _UsersReposetory.CheckIfUsersInsistalrady(userToReposetory.UserName);
            if (!flag)
                return null;
            userToReposetory.UserName = userToReposetory.UserName.ToLower();
            User userFromReposetory= await _UsersReposetory.AddNewUsersRepositories(userToReposetory);

            UserDTO userToController = _Imapper.Map<UserDTO>(userFromReposetory);
            return userToController;
        }

        public async Task<bool> CheckIfUsersInsistalradyServise(string user)
        {

           
            return await _UsersReposetory.CheckIfUsersInsistalrady(user);
            
        }




        //post login user
        public async Task<UserDTO> LoginUsersService(LoginUserDTO logInUser)
        {
            User userToRposetory = _Imapper.Map<User>(logInUser);


            User? userFromRposetory= await _UsersReposetory.LoginUsersRepositories(userToRposetory);

            UserDTO userToConroller = _Imapper.Map<UserDTO>(userFromRposetory);

            return  userToConroller;
        }

         async public Task<bool> UpdateUsersService(int id, UpdateUserDTO userToUpdate)
        {

            if (id != userToUpdate.UserId)
                return false;

            User userToRposetory = _Imapper.Map<User>(userToUpdate);
            User? checkUserValidtion = await _UsersReposetory.GetByIDUsersRepositories(id);
            if (checkUserValidtion == null)
                return false;
            if (checkUserValidtion.UserName != userToRposetory.UserName)
                return false;
            await _UsersReposetory.UpdateUsersRepositories(id, userToRposetory);
            return true;
        }

    }
}
