using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShope.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicSiteController : ControllerBase
    {
        IBasicSitesServise _IBasicSitesServise;
        public BasicSiteController(IBasicSitesServise _IBasicSitesServise)
        {
            this._IBasicSitesServise = _IBasicSitesServise;

        }

      
        // GET api/<BasicSiteController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BasicSiteDTO>> GetByID(int id)
        {
            BasicSiteDTO basicSite = await _IBasicSitesServise.GetByIDbasicSiteServise(id);
            if (basicSite == null)
            {
                return NoContent();
            }
            return Ok(basicSite);
        }

        // POST api/<BasicSiteController>
        [HttpPost]
        async public Task<ActionResult<BasicSiteDTO>> Post([FromBody] AddBasicSiteDTO basicSite)
        {
            BasicSiteDTO basicSiteConstructedObject = await _IBasicSitesServise.AddBasicSiteServise(basicSite);
            return CreatedAtAction(nameof(GetByID), new { id = basicSiteConstructedObject.BasicSiteID }, basicSiteConstructedObject);
        
        }

        // PUT api/<BasicSiteController>/5
        [HttpPut("{id}")]
        async public Task Put(int id, [FromBody] UpdateBasicSiteDTO basicSite)
        {
            await _IBasicSitesServise.UpdateBasicSiteServise(id, basicSite);
        }

       
    }
}
