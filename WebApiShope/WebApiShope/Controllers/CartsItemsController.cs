using Microsoft.AspNetCore.Mvc;
using DTO;
using Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShope.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsItemsController : ControllerBase
    {

        ICartItemServise _CartItemServise;

        public CartsItemsController(ICartItemServise _CartItemServise)
        {
            this._CartItemServise = _CartItemServise;
        }
        // GET: api/<CartsItemsController>


        // GET api/<CartsItemsController>/5


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartItemDTO>>> GetUserCart([FromQuery] int userId)
        {
            var cartItems = await _CartItemServise.GetUserCartServise(userId);
            if (cartItems == null )
            {
                return NotFound();
            }
            return Ok(cartItems);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CartItemDTO>> GetById(int id)
        {
            CartItemDTO? cartItem = await _CartItemServise.GetByIdServise(id);
            if (cartItem == null)
            {
                return NotFound();
            }
            return Ok(cartItem);
        }

        // POST api/<CartsItemsController>
        [HttpPost]
        public async Task<ActionResult<CartItemDTO>> CreateUserCart([FromBody]  AddToCartDTO dto)
        {
            CartItemDTO newCartItem = await _CartItemServise.CreateUserCartServise(dto);
            if (newCartItem != null)
            {
                return CreatedAtAction(nameof(GetById), new { id = newCartItem.CartID }, newCartItem);
            }
            return BadRequest("Cart item already exists for this user and product.");
        }

        // PUT api/<CartsController/5
        [HttpPut]
        public async Task<ActionResult<CartItemDTO>> UpdateUserCartAsync([FromBody] CartItemDTO dto)
        {
            var updatedCartItem = await _CartItemServise.UpdateUserCartServise(dto);
            if (updatedCartItem == null)
            {
                return NotFound();
            }
            return Ok(updatedCartItem);
        }

        // DELETE api/<CartsItemsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserCartAsync(int id)
        {
            bool succeeded = await _CartItemServise.DeleteUserCartServise(id);
            if (!succeeded)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
