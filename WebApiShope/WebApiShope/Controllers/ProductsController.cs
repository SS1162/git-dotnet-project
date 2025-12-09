using Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShope.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {



        private IProductsService iproductsService;
        public ProductsController(IProductsService iproductsService)
        {
            this.iproductsService = iproductsService;
        }



        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get
        (int? minPrice,  int? maxPrice,int? limit, int? paging, int[]? categoryID)
        //([FromBody] int? [] categoryID ,int? minPrice,  int? maxPrice,int? limit, int? paging)
        {
            IEnumerable<Product> temp = await iproductsService.ReturnProductService(categoryID, minPrice, maxPrice, limit, paging);

            if (temp == null)
            {
                return NoContent();
            }

            return Ok(temp);
           
        }



        

    }
}
