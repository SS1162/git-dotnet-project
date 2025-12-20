using Entities;
using DTO;
namespace Services
{
    public interface IUsersService
    {
        Task<UserDTO> AddNewUsersService(RegisterUserDTO registerUser);
        Task<UserDTO> GetByIDUsersService(int id);
        Task<UserDTO> LoginUsersService(LoginUserDTO logInUser);
        Task UpdateUsersService(int id, UpdateUserDTO userToUpdate);
    }
}