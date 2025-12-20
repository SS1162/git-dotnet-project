using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShope.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private PasswordsService passwordService = new PasswordsService();
        // GET: api/<PasswordController>


        // POST api/<PasswordController>
        [HttpPost]
        public int Post([FromBody] PasswordDTO password)
        {
            return passwordService.CheckPasswordStrength(password);
        }

        // PUT api/<PasswordController>/5

    }
}
