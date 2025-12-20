using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Services;
using Entities;
using DTO;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShope.Controllers
{
  

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersService _IUsersService;

        private IPasswordsService _IPasswordsService;
        public UsersController(IUsersService iusersService, IPasswordsService ipasswordsService)
        {
            this._IUsersService = iusersService;
            this._IPasswordsService = ipasswordsService;
        }
     

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {

            UserDTO user = await _IUsersService.GetByIDUsersService(id);
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
        
        public async Task<ActionResult<UserDTO>> PostLogin([FromBody] LoginUserDTO logInUser)
        {
            UserDTO user = await _IUsersService.LoginUsersService(logInUser);
            if (user == null)
            {
                return Unauthorized();

            }
            else
            {
                return CreatedAtAction(nameof(Get), new { id = user.UserID}, user);
            }

        }


        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post([FromBody] RegisterUserDTO userFromUser)
        {


            PasswordDTO passwordForCheckStrength = new PasswordDTO();
            passwordForCheckStrength.UserPassward = userFromUser.UserPassward;
            if (_IPasswordsService.CheckPasswordStrength(passwordForCheckStrength) <2)
            {
                return BadRequest();
            }

            UserDTO userFromDatabase = await _IUsersService.AddNewUsersService(userFromUser);
            if (userFromDatabase == null)
                return BadRequest();
            return CreatedAtAction(nameof(Get), new { id = userFromDatabase.UserID }, userFromDatabase);
        }
        // PUT api/<UsersController>/5
        [HttpPut("{id}")]

        async public Task<ActionResult> Put(int id, [FromBody] UpdateUserDTO user)
        {
            //לחסום החלפה של שם משתמש
            PasswordDTO passwordForCheckStrength = new PasswordDTO();
            passwordForCheckStrength.UserPassward = user.Password;
            if (_IPasswordsService.CheckPasswordStrength(passwordForCheckStrength) < 2)
            {
                return BadRequest();
            }


            await _IUsersService.UpdateUsersService(id, user);
            return Ok();
        }


    }
}
