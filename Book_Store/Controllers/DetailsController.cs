using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model_Layer;
using Repository_Layer.Custom_Exception;
using Repository_Layer.Interface;

namespace Book_Store.Controllers
{
    [Authorize(Roles ="user")]
    [Route("api/details")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        private readonly IMediator mediator;
        public DetailsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddDetails(CustomerDetailsML customerDetailsML)
        {
            try
            {
                int id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var detail = await mediator.Send(new AddDetailsRequest(
                    customerDetailsML.Address,
                    customerDetailsML.City,
                    customerDetailsML.State,
                    customerDetailsML.AddressType,
                    id
                    ));
                var result = new ResponseML
                {
                    Status = true,
                    Message = "Customer details added successfully",
                    Data = detail
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
        public async Task<IActionResult> GetDetails()
        {
            try
            {
                int id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var detail = await mediator.Send(new GetDetailsRequest(
                    id
                    ));
                var result = new ResponseML
                {
                    Status = true,
                    Message = "Customer details :",
                    Data = detail
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
        public async Task<IActionResult> DeleteDetails(string type)
        {
            try
            {
                int id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var detail = await mediator.Send(new DeleteDetailsRequest(id) { Type = type });
                var result = new ResponseML
                {
                    Status = true,
                    Message = "Customer details deleted successfully",
                    Data = detail
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
        public async Task<IActionResult> UpdateDetails(CustomerDetailsML customerDetailsML)
        {
            try
            {
                int id = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                var detail = await mediator.Send(new UpdateDetailsRequest(   
                    customerDetailsML.Address,
                    customerDetailsML.City,
                    customerDetailsML.State,
                    customerDetailsML.AddressType,
                     id
                    ));
                var result = new ResponseML
                {
                    Status = true,
                    Message = "Customer details updated successfully",
                    Data = detail
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
