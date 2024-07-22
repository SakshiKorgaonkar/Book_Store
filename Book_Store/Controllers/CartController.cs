using Commands.Book;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model_Layer;
using Repository_Layer.Custom_Exception;

namespace Book_Store.Controllers
{
    [Authorize(Roles ="user")]
    [Route("api/carts")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator mediator;
        public CartController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(CartML cartML)
        {
            try
            {
                int id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var bookData = await mediator.Send(new AddToCartRequest(
                    cartML.BookId,
                    cartML.Quantity,
                    id
                    ));
                var result = new ResponseML
                {
                    Status = true,
                    Message = "Book added to cart successfully",
                    Data = bookData
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
        [HttpPut]
        public async Task<IActionResult> UpdateCart(CartML cartML)
        {
            try
            {
                int id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var bookData = await mediator.Send(new UpdateCartRequest(
                    id,
                    cartML.BookId,
                    cartML.Quantity
                    ));
                var result = new ResponseML
                {
                    Status = true,
                    Message = "Cart updated successfully",
                    Data = bookData
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
        public async Task<IActionResult> DeleteFromCart(int bookId)
        {
            try
            {
                int id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var bookData = await mediator.Send(new DeleteFromCartRequest(id) { Id=bookId} );
                var result = new ResponseML
                {
                    Status = true,
                    Message = "Book deleted from cart successfully",
                    Data = bookData
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
        public async Task<IActionResult> GetCart()
        {
            try
            {
                int id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var bookData =await mediator.Send(new GetCartRequest() { Id=id});
                var result = new ResponseML
                {
                    Status = true,
                    Message = "Cart : ",
                    Data = bookData
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
