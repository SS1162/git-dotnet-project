using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShope.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsItemsController : ControllerBase
    {

        ICartItemServise _cartItemServise;

        public CartsItemsController(ICartItemServise cartItemServise)
        {
            this._cartItemServise = cartItemServise;
        }
        // GET: api/<CartsItemsController>


        // GET api/<CartsItemsController>/5


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartItemDTO>>> GetUserCart([FromQuery] int userId)
        {
            Resulte<IEnumerable<CartItemDTO>> cartItems = await _cartItemServise.GetUserCartServise(userId);
            if (!cartItems.IsSuccess)
            {
                return BadRequest(cartItems.ErrorMessage);
            }
            if (cartItems.Data==null)
            {
                return NotFound();
            }
            return Ok(cartItems.Data);
        }




        [HttpGet("{id}")]
        public async Task<ActionResult<CartItemDTO>> GetById(int id)
        {
            CartItemDTO? cartItem = await _cartItemServise.GetByIdServise(id);
            if (cartItem == null)
            {
                return NotFound();
            }
            return Ok(cartItem);
        }

        // POST api/<CartsItemsController>
        [HttpPost]
        public async Task<ActionResult<CartItemDTO>> CreateUserCart([FromBody] AddToCartDTO dto)
        {
            Resulte<CartItemDTO> newCartItem = await _cartItemServise.CreateUserCartServise(dto);
            if (!newCartItem.IsSuccess)
            {
                return BadRequest(newCartItem.ErrorMessage);
            }

            return CreatedAtAction(nameof(GetById), new { id = newCartItem.Data.CartID }, newCartItem.Data);

        }

        
        // DELETE api/<CartsItemsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserCart(int id)
        {
             Resulte<CartItemDTO?> resulte = await _cartItemServise.DeleteUserCartServise(id);
            if (!resulte.IsSuccess)
            {
                return BadRequest(resulte.ErrorMessage);
            }
            return Ok();
        }


        [HttpPut("changeToValid/{id}")]

        public async Task<IActionResult> ChangeProductToValid(int id)
        {
            Resulte<CartItemDTO?> resulte = await _cartItemServise.ChangeProductToValidCartServise(id);
            if (!resulte.IsSuccess)
            {
                return BadRequest(resulte.ErrorMessage);
            }
            return Ok();
        }


        [HttpPut("changeToNotValid/{id}")]

        public async Task<IActionResult> ChangeProductToNotValid(int id)
        {
            Resulte<CartItemDTO?> resulte = await _cartItemServise.ChangeProductToNotValidCartServise(id);
            if (!resulte.IsSuccess)
            {
                return BadRequest(resulte.ErrorMessage);
            }
            return Ok();
        }
    }
}
