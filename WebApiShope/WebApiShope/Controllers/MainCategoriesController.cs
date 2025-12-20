using DTO;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Reflection.Metadata.Ecma335;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShope.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainCategoriesController : ControllerBase
    {
        IMainCategoriesServise _IMainCategoriesServise;
        public MainCategoriesController(IMainCategoriesServise _mainCategoriesServise)
        {
            this._IMainCategoriesServise = _mainCategoriesServise;
        }

        // GET: api/<MainCategoriesController>
        [HttpGet]
        async public Task<ActionResult<IEnumerable<MainCategoriesDTO>>> Get()
        {
            IEnumerable<MainCategoriesDTO> MainCategoriesList = await _IMainCategoriesServise.GetMainCategoriesServises();
            if (MainCategoriesList == null)
            {
                return NoContent();
            }
            return Ok(MainCategoriesList);
        }


        // POST api/<MainCategoriesController>
        [HttpPost]
        async public Task<ActionResult<MainCategoriesDTO>> Post([FromBody] ManegerMainCategoryDTO manegerMainCategory)
        {
            MainCategoriesDTO mainCategoryConstructedObject = await _IMainCategoriesServise.AddMainCategoriesServises(manegerMainCategory);
            return CreatedAtAction(nameof(Get), new { id = mainCategoryConstructedObject.MainCategoryID }, mainCategoryConstructedObject); 
        }

        // PUT api/<MainCategoriesController>/5
        [HttpPut("{id}")]
        async public Task Put(int id, [FromBody] MainCategoriesDTO mainCategory)
        {
            await _IMainCategoriesServise.UpdateMainCategoriesServises(id, mainCategory);
        }

        // DELETE api/<MainCategoriesController>/5
        [HttpDelete("{id}")]
        async public Task<ActionResult> Delete(int id)
        {
            bool flag = await _IMainCategoriesServise.DeleteMainCategoriesServises(id);
            if (flag)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
