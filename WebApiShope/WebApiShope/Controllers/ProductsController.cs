using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShope.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductsServise _IProductsServise;

        public ProductsController(IProductsServise _IProductsServise)
        {
            this._IProductsServise = _IProductsServise; 
        }
        // GET: api/<ProductsController>
        [HttpGet]
        async public Task<ActionResult<IEnumerable<ProductDTO>>> Get(int categoryID)
        {
            IEnumerable<ProductDTO> productsList = await _IProductsServise.GetProductsServise(categoryID);
            if (productsList == null)
                return NoContent();
            return Ok(productsList);
        }

    
        // POST api/<ProductsController>
        [HttpPost]
        async public Task<ActionResult<ProductDTO>> Post([FromBody] AddProductDTO product)
        {

            ProductDTO productConstructedObject = await _IProductsServise.AddProductServise(product);
            return CreatedAtAction(nameof(Get), new { id = productConstructedObject.ProductsID }, productConstructedObject);
        
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        async public Task Put(int id, [FromBody] UpdateProductDTO productToUpdate )
        {
            await _IProductsServise.UpdateProductServise(id, productToUpdate);

        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        async public Task<ActionResult> Delete(int id)
        {

            bool flag = await _IProductsServise.DeleteIDProductServise(id);
            if (flag)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
    
}
