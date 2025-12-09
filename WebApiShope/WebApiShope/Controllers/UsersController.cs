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
        private IUsersService iusersService;

        private IPasswordService ipasswordService;
        public UsersController(IUsersService iusersService, IPasswordService ipasswordService)
        {
            this.iusersService = iusersService;
            this.ipasswordService= ipasswordService;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            
            User user= await iusersService.GetByIDUsersService(id);
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
        
        public async Task<ActionResult<User>> PostLogin([FromBody] LoginUser logInUser)
        {
            User user = await iusersService.LoginUsersService(logInUser);
            if (user == null)
            {
                return Unauthorized();

            }
            else
            {
                return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
            }

        }


        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User userFromUser)
        {
            Password passwordForCheckStrength = new Password();
            passwordForCheckStrength.UserPassward = userFromUser.Password;
            if (ipasswordService.CheckPasswordStrength(passwordForCheckStrength) <2)
            {
                return BadRequest();
            }

            User userFromDatabase = await iusersService.AddNewUsersService(userFromUser);
            if (userFromDatabase == null)
                return NoContent();
            return CreatedAtAction(nameof(Get), new { id = userFromDatabase.UserId }, userFromDatabase);
        }
        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public   ActionResult Put(int id, [FromBody] User user)
        {
            Password passwordForCheckStrength = new Password();
            passwordForCheckStrength.UserPassward = user.Password;
            if (ipasswordService.CheckPasswordStrength(passwordForCheckStrength) < 2)
            {
                return BadRequest();
            }
            iusersService.UpdateUsersService(id, user);
            return Ok();
        }

    
    }
}
