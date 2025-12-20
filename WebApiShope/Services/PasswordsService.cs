using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zxcvbn;
namespace Services
{
    public class PasswordsService : IPasswordsService
    {
        public int CheckPasswordStrength(PasswordDTO password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password.UserPassward);
            int scoreOfPassword = result.Score;
            return scoreOfPassword;
        }

    }
}
