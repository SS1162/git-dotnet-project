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
        IProductsServise _productsServise;

        public ProductsController(IProductsServise productsServise)
        {
            this._productsServise = productsServise; 
        }
        // GET: api/<ProductsController>
        [HttpGet]
        async public Task<ActionResult<Resulte<ResponePage<ProductDTO>>>> Get(int categoryID, int numOfPages, int PageSize, string? search, int? minPrice, int? MaxPrice, bool? orderByPrice, bool? desc)
        {
            Resulte<ResponePage<ProductDTO>> respone = await _productsServise.GetProductsServise( categoryID,  numOfPages,  PageSize,  search,  minPrice,   MaxPrice,  orderByPrice,   desc);
           if(!respone.IsSuccess)
            {
                return BadRequest(respone.ErrorMessage);
            }
           if(!respone.Data.Data.Any())
            {
                return NoContent();
            }
            return Ok(respone.Data);
        }

    
        // POST api/<ProductsController>
        [HttpPost]
        async public Task<ActionResult<ProductDTO>> Post([FromBody] AddProductDTO product)
        {

            ProductDTO productConstructedObject = await _productsServise.AddProductServise(product);
            return CreatedAtAction(nameof(Get), new { id = productConstructedObject.ProductsID }, productConstructedObject);
        
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        async public Task Put(int id, [FromBody] UpdateProductDTO productToUpdate )
        {
            await _productsServise.UpdateProductServise(id, productToUpdate);

        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        async public Task<ActionResult> Delete(int id)
        {

            bool flag = await _productsServise.DeleteIDProductServise(id);
            if (flag)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
    
}
