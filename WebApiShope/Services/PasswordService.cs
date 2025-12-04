using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zxcvbn;
namespace Services
{
    public class PasswordService : IPasswordService
    {
        public int CheckPasswordStrength(Password password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password.UserPassward);
            int scoreOfPassword = result.Score;
            return scoreOfPassword;
        }

    }
}
