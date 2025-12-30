using DTO;
using Microsoft.AspNetCore.Mvc;
using Services;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShope.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteTypesController : ControllerBase
    {
        ISiteTypesService _SiteTypesService;
        public SiteTypesController(ISiteTypesService _SiteTypesService)
        {
            this._SiteTypesService = _SiteTypesService;
        }
        // GET: api/<SiteTypeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SiteTypeDTO>?>> GetAll()
        {
            var siteTypes = await _SiteTypesService.GetAllSiteTypesServise();
            if (siteTypes == null )
            {
                return NotFound();
            }
            return Ok(siteTypes);
        }


        // GET api/<SiteTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SiteTypeDTO>> GetById(int id)
        {
            SiteTypeDTO siteType = await _SiteTypesService.GetSiteTypesByIdServise(id);
            if(siteType == null )
                return NotFound();
            return Ok(siteType);
        }

        // POST api/<SiteTypeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}/manager")]
        public async Task UpdateByMng(int id, SiteTypeDTO dto)
        {
             await _SiteTypesService.UpdateSiteTypesByMngServise(id, dto);
        }


    }
}
