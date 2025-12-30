using DTO;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShope.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        IReviewsServise _IReviewsServise;
        public ReviewController() { }
        // POST api/<OrdersController>/5/review   
        [HttpPost]
        public async Task<ActionResult<ReviewDTO>> AddReviewAsync(int orderId, AddReviewDTO dto)
        {
            ReviewDTO newReview = await _IReviewsServise.AddReviewServise(orderId, dto);
            return CreatedAtAction(nameof(GetReviewByOrderId), new { id = orderId }, newReview);
        }

        // GET api/<OrdersController>/5/review
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewDTO>> GetReviewByOrderId([FromBody] int orderId)
        {
            ReviewDTO review = await _IReviewsServise.GetReviewByOrderIdServise(orderId);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        // PUT api/<OrdersController>/5/review
        [HttpPut("{id}")]
        public async Task UpdateReviewAsync(int id,[FromBody] ReviewDTO dto)
        {
           
            await _IReviewsServise.UpdateReviewServise(id,dto);
            
        }

     
       
    }
}
