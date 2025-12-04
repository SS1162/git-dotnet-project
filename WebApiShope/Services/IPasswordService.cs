using Entities;

namespace Services
{
    public interface IPasswordService
    {
        int CheckPasswordStrength(Password password);
    }
}