using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Services;
using Entities;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShope.Controllers
{
  

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UsersService usersService=new UsersService();
       // GET: api/<UsersController>
       [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<Users> Get(int id)
        {
            
            Users user= usersService.GetByIDUsersService(id);
            if (user == null)
            {
                return NoContent();
            }
            else
                return user;

        }


        // POST api/<UsersController>

        //POST request

        [HttpPost("loginFunction")]
        
        public ActionResult<LoginUser> PostLogin([FromBody] LoginUser logInUser)
        {
            LoginUser user = usersService.LoginUsersService(logInUser);
            if (user == null)
            { return NoContent(); }
            else
            {
                return CreatedAtAction(nameof(Get), new { id = user.UserID }, user);
            }
                

        }


        [HttpPost]
        public ActionResult<Users> Post([FromBody] Users userFromUser)
        {
            Users userFromDatabase = usersService.AddNewUsersService(userFromUser);
            if (userFromDatabase == null)
                return NoContent();
            return CreatedAtAction(nameof(Get), new { id = userFromDatabase.UserID }, userFromDatabase);
        }
        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id,Users value)
        {

            usersService.UpdateUsersService(id, value);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
