using DTO;
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
        public Resulte<int> CheckPasswordStrength(PasswordDTO password)
        {

            if (password.UserPassward == "")
            {
                return Resulte<int>.Failure("The password field is empty");
            }
            var result = Zxcvbn.Core.EvaluatePassword(password.UserPassward);
            int scoreOfPassword = result.Score;
             return Resulte<int>.Success(scoreOfPassword);
        }

    }
}
