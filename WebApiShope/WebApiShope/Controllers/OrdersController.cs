using Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShope.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {


        private IOrdersService iordersService;
        public OrdersController(IOrdersService iordersService)
        {
            this.iordersService = iordersService;
        }


      



        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        async public Task<ActionResult<Order>> Get(int id)
        {

         Order  temp = await iordersService.ReturnOrderByIdService(id);
            if (temp==null)
            {
                return NoContent();
            }
            return temp;
        }


        [HttpPost]
        async public Task<ActionResult<Order>> Post([FromBody] Order order )
        {

            Order temp= await iordersService.AddOrdersService(order);


            return CreatedAtAction(nameof(Get), new { id = temp.OrderId }, temp);    
        }

    }
}
