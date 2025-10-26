using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShope.Controllers
{
  

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        string filePath = "users.txt";
       // GET: api/<UsersController>
       [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        //[HttpGet("Login")]
        //public IEnumerable<string> Get2()
        //{
        //    return new string[] { "value4", "value5" };
        //}

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        //get user login

        



        // POST api/<UsersController>
        

        

        //POST request
       

        [HttpPost]
        public ActionResult<LoginUser> Post2([FromBody] LoginUser LogInUser)
        {

            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    users use = JsonSerializer.Deserialize<users>(currentUserInFile);
                    if (use.UserName == LogInUser.UserName && use.UserPassward == LogInUser.UserPassward)
                        return CreatedAtAction(nameof(Get), new { id = use.UserID }, use);
                }
            }
            return NoContent();
        }


        [HttpPost("login")]
        public ActionResult<users> Post([FromBody] users user)
        {
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.UserID = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            return CreatedAtAction(nameof(Get), new { id = user.UserID }, user);
        }
        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] users value)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
               
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    users user = JsonSerializer.Deserialize<users>(currentUserInFile);
                    if (user.UserID == id)
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

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
