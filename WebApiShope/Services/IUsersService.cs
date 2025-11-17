using Entities;

namespace Services
{
    public interface IUsersService
    {
        Users AddNewUsersService(Users user);
        Users GetByIDUsersService(int id);
        LoginUser LoginUsersService(LoginUser logInUser);
        void UpdateUsersService(int id, Users value);
    }
}