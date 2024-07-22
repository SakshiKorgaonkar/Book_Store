using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model_Layer;
using Repository_Layer.Custom_Exception;

namespace Book_Store.Controllers
{
    [Authorize(Roles ="user")]
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;
        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                int id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var orders = await mediator.Send(new GetOrdersRequest() { Id = id });
                var result = new ResponseML
                {
                    Status = true,
                    Message = "All orders",
                    Data = orders
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
        [HttpPost]
        public async Task<IActionResult> PlaceOrder(OrdersML ordersML)
        {
            try
            {
                int id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var order = await mediator.Send(new PlaceOrderRequest(
                    ordersML.CustomerDetailId
                    ) { Id = id });
                var result = new ResponseML
                {
                    Status = true,
                    Message = "Order placed successfully",
                    Data = order
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
