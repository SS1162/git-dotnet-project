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
        private PasswordService passwordService = new PasswordService();
        // GET: api/<PasswordController>
       

        // POST api/<PasswordController>
        [HttpPost]
        public int Post([FromBody] Password password)
        {
            return passwordService.CheckPasswordStrength(password);
        }

        // PUT api/<PasswordController>/5
       
    }
}
