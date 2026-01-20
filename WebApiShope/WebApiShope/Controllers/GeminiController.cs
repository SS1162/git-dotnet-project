using Microsoft.AspNetCore.Mvc;
using Services;
using DTO;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShope.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeminiController : ControllerBase
    {

        IGeminiServise _geminiServise;

        public GeminiController(IGeminiServise geminiServise)
        {
            this._geminiServise = geminiServise;    
        }

        // GET: api/<GeminiController>
        [HttpGet("getUserProduct")]
        public   async  Task<ActionResult<string>> Get(int productId ,string userRequest)
        {
            Resulte<string> resulte= await _geminiServise.getGeminiForUserProductServise(productId, userRequest);
            if (!resulte.IsSuccess)
                return BadRequest(resulte.ErrorMessage);
            return Ok(resulte.Data);
        }

        // GET api/<GeminiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GeminiController>
        [HttpPost("addNewProduct")]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<GeminiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GeminiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
