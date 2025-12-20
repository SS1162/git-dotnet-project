using Microsoft.AspNetCore.Mvc;
using Services;
using DTO;
using Microsoft.AspNetCore.Http.HttpResults;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShope.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoriesServise _ICategoriesServise;
        public CategoriesController(ICategoriesServise _ICategoriesServise) {
            this._ICategoriesServise = _ICategoriesServise;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        async public Task<ActionResult<IEnumerable<CategoryDTO>>> Get(int paging, int limit, string? search, int? minPrice, int? MaxPrice, int? mainCategoryID)
        {
            IEnumerable<CategoryDTO> categoryList=await _ICategoriesServise.GetCategoriesServise(paging, limit, search, minPrice, MaxPrice, mainCategoryID);
            if (categoryList == null)
                return NoContent();
            return Ok(categoryList);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        async public Task<ActionResult<CategoryDTO>> GetByID(int id)
        {
            CategoryDTO category =await _ICategoriesServise.GetByIDCategoriesServise(id);
            if(category==null)
            {
                return NoContent();
            }
            return Ok(category);
        }

        // POST api/<CategoryController>
        [HttpPost]
       async  public Task<ActionResult<CategoryDTO>> Post([FromBody] AddCategoryDTO category)
        {
            CategoryDTO categoryConstructedObject=await _ICategoriesServise.AddCategoriesServise(category);
            return CreatedAtAction(nameof(GetByID), new { id = categoryConstructedObject.CategoryID }, categoryConstructedObject);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        async public Task Put(int id, [FromBody] CategoryDTO category)
        {
            await _ICategoriesServise.UpdateCategoriesServise(id, category);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        async public Task<ActionResult> Delete(int id )
        {
            bool flag=await _ICategoriesServise.DeleteIDCategoriesServise(id);
            if(flag)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
