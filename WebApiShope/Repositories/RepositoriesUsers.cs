using Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
namespace Repositories
{

    public class RepositoriesUsers : IRepositoriesUsers
    {
        private readonly MyShop330683525Context _context;

        public RepositoriesUsers(MyShop330683525Context context)
        {
            _context = context;
        }

        //M:\web api\project_from_git\git-dot.net-project\WebApiShope\Repositories\users.txt
        //Post new user 
        public async Task<User> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        //Get by ID  new user 
        public async Task<User?> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        ////Post login user
        public async Task<User?> Login(LoginUser logInUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => logInUser.UserName == x.UserName &&
            logInUser.UserPassward == x.Password);
            return user;
        }

        //Put 
        public async Task UpdateUser(int id, User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

    }
}
