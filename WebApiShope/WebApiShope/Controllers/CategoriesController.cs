using Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShope.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private ICategoriesService icategoriesService;
        public CategoriesController(ICategoriesService icategoriesService)
        {
            this.icategoriesService = icategoriesService;
        }


        // GET: api/<CategoriesController>
        [HttpGet]
        async public Task<ActionResult<IEnumerable<Category>>> Get()
        {
            IEnumerable<Category> temp = await icategoriesService.ReturnCategoryService();

            if (temp==null)
            {
                return NoContent();
            }

            return Ok(temp);
        }

     

      

      

     
    }
}
