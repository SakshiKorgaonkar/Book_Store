using Commands.Book;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model_Layer;
using Repository_Layer.Custom_Exception;
using System.Security.Claims;

namespace Book_Store.Controllers
{
    [Authorize(Roles ="admin")]
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator mediator;
        public BookController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookML bookML)
        {
            try
            {
                int id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var book = await mediator.Send(new AddBookRequest(
                    bookML.Name,
                    bookML.Description,
                    bookML.Price,
                    bookML.DiscountedPrice,
                    bookML.Author,
                    bookML.Quantity,
                    bookML.Image,
                    id
                    ));
                var result = new ResponseML
                {
                    Status = true,
                    Message = "Book added successfully",
                    Data = book
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
        public async Task<IActionResult> RemoveBookById(int id)
        {
            try
            {
                var book = await mediator.Send(new RemoveBookByIdRequest() { Id = id });
                var result = new ResponseML
                {
                    Status = true,
                    Message = "Book removed successfully",
                    Data = book
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
        [HttpGet("byId")]
        public async Task<IActionResult> GetBookById(int id)
        {
            try
            {
                var book = await mediator.Send(new GetBookByIdRequest() { Id = id });
                var result = new ResponseML
                {
                    Status = true,
                    Message = "Book by id : ",
                    Data = book
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
        public async Task<IActionResult> UpdateBookById(int bookId,BookML bookML)
        {
            try
            {
                int id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var book = await mediator.Send(new UpdateBookByIdRequest(
                    bookId,
                    bookML.Name,
                    bookML.Description,
                    bookML.Price,
                    bookML.DiscountedPrice,
                    bookML.Author,
                    bookML.Quantity,
                    bookML.Image,
                    id));
                var result = new ResponseML
                {
                    Status = true,
                    Message = "Book updated successfully",
                    Data = book
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
        public async Task<IActionResult> GetBooks()
        {
            try
            {
                var book =await mediator.Send(new GetBooksRequest());
                var result = new ResponseML
                {
                    Status = true,
                    Message = "Books : ",
                    Data = book
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
