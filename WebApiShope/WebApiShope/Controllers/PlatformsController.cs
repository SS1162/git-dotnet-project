using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShope.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        IPlatformsServise _IPlatformsServise;
        public PlatformsController(IPlatformsServise _IPlatformsServise) {
            this._IPlatformsServise = _IPlatformsServise;
        }
        // GET: api/<PlatformsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlatformsDTO>>> Get()
        {
           IEnumerable < PlatformsDTO > platformList = await _IPlatformsServise.GetPlatformsServise();
            if (platformList == null)
            {
                return NoContent();
            }
            else
                return Ok(platformList);
        }

     

        // POST api/<PlatformsController>
        [HttpPost]
        public async Task<ActionResult<PlatformsDTO>> Post([FromBody] AddPlatformDTO platform)
        {
          
           PlatformsDTO PlatformForReturn= await _IPlatformsServise.AddPlatformServise(platform);

            return CreatedAtAction(nameof(Get), new { id = PlatformForReturn.PlatformID }, PlatformForReturn);
        }

        // PUT api/<PlatformsController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] PlatformsDTO platform)
        {
            await _IPlatformsServise.UpdatePlatformServise(id,platform);
        }

        // DELETE api/<PlatformsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool flag = await _IPlatformsServise.DeletePlatformServise(id);
            if (flag)
                return Ok();
            return BadRequest();
        }
    }
}
