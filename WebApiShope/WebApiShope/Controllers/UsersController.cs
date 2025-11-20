using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShope.Controllers
{
  

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly string filePath = Path.Combine(Directory.GetCurrentDirectory(), "users.txt");
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
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    Users userFromFile = JsonSerializer.Deserialize<Users>(currentUserInFile);
                    if (userFromFile.UserID == id)
                        return userFromFile;
                }
            }
            return NotFound();

        }


        // POST api/<UsersController>

        //POST request

        [HttpPost("loginFunction")]
        
        public ActionResult<LoginUser> PostLogin([FromBody] LoginUser LogInUser)
        {

            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    Users userFromFile = JsonSerializer.Deserialize<Users>(currentUserInFile);
                    if (userFromFile.UserName == LogInUser.UserName && userFromFile.UserPassward == LogInUser.UserPassward)
                        return Ok(userFromFile);
                }
            }
            return Unauthorized();
        }


        [HttpPost]
        public ActionResult<Users> Post([FromBody] Users user)
        {
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.UserID = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            return CreatedAtAction(nameof(Get), new { id = user.UserID }, user);
        }
        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Users value)
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
                return NoContent();
            }
            return NotFound();
        }
    }
}
