using Commands;
using Commands.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model_Layer;
using Repository_Layer.Context;
using Repository_Layer.Custom_Exception;
using Repository_Layer.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;

namespace Book_Store.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;
        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("registerUser")]
        public async Task<IActionResult> AddUser(UserML userML)
        {
            try
            {
                var user = await mediator.Send(new AddUserRequest(
                userML.Name,
                userML.Email,
                userML.Password,
                userML.Phone,
                "user"
                ));
                var result = new ResponseML
                {
                    Status = true,
                    Message = "User registered successfully",
                    Data = user
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
        [HttpPost("registerAdmin")]
        public async Task<IActionResult> AddAdmin(UserML userML)
        {
            var studentDetail = await mediator.Send(new AddUserRequest(
                userML.Name,
                userML.Email,
                userML.Password,
                userML.Phone,
                "admin"));
            var result = new ResponseML
            {
                Status = true,
                Message = "Admin registered successfully",
                Data = studentDetail
            };
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginML loginML)
        {
            try
            {
                var studentDetail = await mediator.Send(new LoginRequest(
                loginML.Email,
                loginML.Password
                ));
                var result = new ResponseML
                {
                    Status = true,
                    Message = "User logged in successfully",
                    Data = studentDetail
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
        [HttpPost("forgot")]
        public async Task<IActionResult> ForgotPassword(string emailId)
        {
            try
            {
                var token=await mediator.Send(new ForgotPasswordRequest(emailId));
                var result = new ResponseML
                {
                    Status = true,
                    Message = "Email with reset link sent successfully",
                    Data = token
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
        [HttpPost("reset")]
        public async Task<IActionResult> ResetPassword(string token,[FromBody] string newPassword)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);
                var email = jwtToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
                var user = await mediator.Send(new ResetPasswordRequest(email, newPassword));
                var result = new ResponseML
                {
                    Status = true,
                    Message = "Password was changed successfully",
                    Data = user
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
