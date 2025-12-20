using Entities;

namespace Services
{
    public interface IPasswordsService
    {
        int CheckPasswordStrength(PasswordDTO password);
    }
}