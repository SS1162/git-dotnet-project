using DTO;
using Entities;

namespace Services
{
    public interface IPasswordsService
    {
        Resulte<int> CheckPasswordStrength(PasswordDTO password);
    }
}