using DTO;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShope.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrdersServise _OrdersServise;
        public OrdersController(IOrdersServise _OrdersServise)
        {
            this._OrdersServise= _OrdersServise;
        }
        // GET: api/<OrdersController>
        [HttpGet("{orderId}/orderItems")]
        async public Task<ActionResult<IEnumerable<OrderItemDTO>>> Get([FromBody] int orderId)
        {
            var orderItems = await _OrdersServise.GetOrderItemsServise(orderId);
            if (orderItems == null )
            {
                return NotFound($"No order items found for Order ID {orderId}");
            }
            return Ok(orderItems);
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FullOrderDTO>> GetByID(int id)
        {
            FullOrderDTO order = await _OrdersServise.GetByIdOrderServise(id);
            if (order == null)
            {
                return NoContent();
            }
            return Ok(order);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<ActionResult<FullOrderDTO>> Post([FromBody] OrdersDTO order)
        {
            FullOrderDTO orderThatCreated =await _OrdersServise.AddOrderServise(order);
            return CreatedAtAction(nameof(GetByID), new { id = orderThatCreated.OrderID}, orderThatCreated);

        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        async public Task Put(int id, [FromBody] FullOrderDTO order)
        {
            await _OrdersServise.UpdateStatusServise(id, order);

        }

        
    }
}
