using Entities;
using System.Text.Json;
namespace Repositories
{

    public class RepositoriesUsers
    {
        string filePath = "..\\Repositories\\users.txt";
        //M:\web api\project_from_git\git-dot.net-project\WebApiShope\Repositories\users.txt
        //Post new user 
        public Users AddNewUsersRepositories(Users user) {

            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.UserID = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            return user;

        }

        //Get by ID  new user 
        public Users GetByIDUsersRepositories(int id )
        {

            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    Users userFromFile = JsonSerializer.Deserialize<Users>(currentUserInFile);
                    if (userFromFile.UserID == id)
                        return userFromFile;
                }
                return null;
            }

        }

        ////Post login user

        public LoginUser LoginUsersRepositories(LoginUser LogInUser)
        {

            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    Users userFromFile = JsonSerializer.Deserialize<Users>(currentUserInFile);
                    if (userFromFile.UserName == LogInUser.UserName && userFromFile.UserPassward == LogInUser.UserPassward)
                        return LogInUser;
                }
                return null;
            }
        }

        //Put 
        public void UpdateUsersRepositories(int id,Users value)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {

                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    Users userFromFile = JsonSerializer.Deserialize<Users>(currentUserInFile);
                    if (userFromFile.UserID == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(value));
                System.IO.File.WriteAllText(filePath, text);
            }
        }

    }
}
