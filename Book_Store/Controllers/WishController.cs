using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model_Layer;
using Repository_Layer.Custom_Exception;

namespace Book_Store.Controllers
{
    [Route("api/wishlists")]
    [ApiController]
    public class WishController : ControllerBase
    {
        private readonly IMediator mediator;
        public WishController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddToWishlist(int bookId)
        {
            try
            {
                int id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var wishlist = await mediator.Send(new AddToWishlistRequest(id) { BookId = bookId });
                var result = new ResponseML
                {
                    Status = true,
                    Message = "Book added to wishlist successfully",
                    Data = wishlist
                };
                return Ok(result);
            }
            catch (CustomException ex)
            {
                var result = new ResponseML
                {
                    Status = false,
                    Message = ex.Message,
                    Data = null
                };
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                var result = new ResponseML
                {
                    Status = false,
                    Message = ex.Message,
                    Data = null
                };
                return StatusCode(500, result);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetWishlist()
        {
            try
            {
                int id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var wishlist = await mediator.Send(new GetWishlistRequest(id));
                var result = new ResponseML
                {
                    Status = true,
                    Message = "Wishlist : ",
                    Data = wishlist
                };
                return Ok(result);
            }
            catch (CustomException ex)
            {
                var result = new ResponseML
                {
                    Status = false,
                    Message = ex.Message,
                    Data = null
                };
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                var result = new ResponseML
                {
                    Status = false,
                    Message = ex.Message,
                    Data = null
                };
                return StatusCode(500, result);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveFromWishlist(int bookId)
        {
            try
            {
                int id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var wishlist = await mediator.Send(new RemoveFromWishlistRequest(id) { BookId = bookId  });
                var result = new ResponseML
                {
                    Status = true,
                    Message = "Book removed from wishlist successfully",
                    Data = wishlist
                };
                return Ok(result);
            }
            catch (CustomException ex)
            {
                var result = new ResponseML
                {
                    Status = false,
                    Message = ex.Message,
                    Data = null
                };
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                var result = new ResponseML
                {
                    Status = false,
                    Message = ex.Message,
                    Data = null
                };
                return StatusCode(500, result);
            }
        }
    }
}
