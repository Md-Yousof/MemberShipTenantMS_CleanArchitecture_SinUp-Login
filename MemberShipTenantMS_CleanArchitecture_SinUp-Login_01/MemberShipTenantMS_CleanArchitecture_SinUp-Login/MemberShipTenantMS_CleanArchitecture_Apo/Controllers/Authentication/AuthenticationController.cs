using MemberShipTenantMS_CleanArchitecture_Application.Authentication;
using MemberShipTenantMS_CleanArchitecture_Application.DTO_s.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MemberShipTenantMS_CleanArchitecture_Apo.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationService _authService;
        public AuthenticationController(AuthenticationService authenticationService)
        {
            _authService = authenticationService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto registerUser, /*[FromQuery] */string role)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            var result = await _authService.RegisterUsers(registerUser, role);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ResponseDto { Status = "Error", Message = result.Errors.First().Description });
            }
            return Ok(new ResponseDto { Status = "Success", Message = "User created successfully!" });
        }


        //[HttpGet("ConfirmEmail")]
        //public async Task<IActionResult> ConfirmEmail([FromQuery] string token, [FromQuery] string email)
        //{
        //    var result = await _authService.ConfirmEmail(token, email);

        //    if (result.Status == "Error")
        //    {
        //        return BadRequest(result.Message);
        //    }

        //    return Ok(result.Message);
        //}

       
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LogingUserDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseDto { Status = "Error", Message = "Invalid login data" });
            }

            // Call the service to authenticate the user and generate the token
            var result = await _authService.LoginUser(loginDto);

            if (result.Status == "Error")
            {
                return Unauthorized(result); // Return 401 Unauthorized for invalid login attempts
            }

            // Return token and success message
            return Ok(result); // Return 200 OK with token and expiration details
        }
    }

}

