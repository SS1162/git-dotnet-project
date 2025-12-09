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
        private readonly IUsersService _usersService;

        private readonly IPasswordService _passwordService;
        public UsersController(IUsersService usersService, IPasswordService passwordService)
        {
            _usersService = usersService;
            _passwordService = passwordService;
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
            
            User user= await _usersService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            else
                return Ok(user);
        }


        // POST api/<UsersController>

        //POST request

        [HttpPost("loginFunction")]
        
        public async Task<ActionResult<User>> PostLogin([FromBody] LoginUser logInUser)
        {
            User user = await _usersService.Login(logInUser);
            if (user == null)
            {
                return Unauthorized();

            }
            else
            {
                return Ok(user);
            }

        }


        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User userFromUser)
        {
            Password passwordForCheckStrength = new Password();
            passwordForCheckStrength.UserPassward = userFromUser.Password;
            if (_passwordService.CheckPasswordStrength(passwordForCheckStrength) <2)
            {
                return BadRequest();
            }

            User userFromDatabase = await _usersService.AddUser(userFromUser);
            if (userFromDatabase == null)
                return NoContent();
            return CreatedAtAction(nameof(Get), new { id = userFromDatabase.UserId }, userFromDatabase);
        }
        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] User user)
        {
            Password passwordForCheckStrength = new Password();
            passwordForCheckStrength.UserPassward = user.Password;
            if (_passwordService.CheckPasswordStrength(passwordForCheckStrength) < 2)
            {
                return BadRequest();
            }
            await _usersService.UpdateUser(id, user);
            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
