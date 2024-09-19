using MemberShipTenantMS_CleanArchitecture_Application.DTO_s.Authentication;
using MemberShipTenantMS_CleanArchitecture_Application.Services;
//using MemberShipTenantMS_CleanArchitecture_Application.Services.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;



namespace MemberShipTenantMS_CleanArchitecture_Application.Authentication
{
    public class AuthenticationService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;
       // private readonly IEmailService _emailService;

        public AuthenticationService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, ITokenService tokenService /*,IEmailService emailService*/)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _tokenService = tokenService;
           // _emailService = emailService;
        }

        public async Task<IdentityResult> RegisterUsers(RegisterUserDto registerUser, string role)
        {
            // Check if the user already exists
            var userExist = await _userManager.FindByEmailAsync(registerUser.Email);
            if (userExist != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User already exists!" });
            }

            // Check if the role exists
            if (!await _roleManager.RoleExistsAsync(role))
            {
                return IdentityResult.Failed(new IdentityError { Description = "Role does not exist!" });
            }

            // Create a new user
            IdentityUser user = new()
            {
                Email = registerUser.Email,
                UserName = registerUser.UserName,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (result.Succeeded)
            {
                //// Assign role to the user if user creation is successful
                await _userManager.AddToRoleAsync(user, role);


                //// Generate email confirmation token and send email
                //var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //var confirmationLink = $"https://localhost:7259/api/authentication/confirmemail?token={token}&email={user.Email}";
                ////var confirmationLink = Url.Action(nameof(ConfirmEmail), "Authentication", new { token, email = user.Email }, Request.Scheme);

                //var message = new Message(new string[] { user.Email! }, "Confirmation email link", confirmationLink!);
                //_emailService.SendEmail(message);


                return IdentityResult.Success;
            }

            return IdentityResult.Failed(new IdentityError { Description = "User creation failed!" });
        }



        //public async Task<ResponseDto> ConfirmEmail(string token, string email)
        //{
        //    var user = await _userManager.FindByEmailAsync(email);
        //    if (user == null)
        //    {
        //        return new ResponseDto { Status = "Error", Message = "User not found!" };
        //    }

        //    var result = await _userManager.ConfirmEmailAsync(user, token);
        //    if (result.Succeeded)
        //    {
        //        return new ResponseDto { Status = "Success", Message = "Email verified successfully!" };
        //    }

        //    return new ResponseDto { Status = "Error", Message = "Email confirmation failed!" };
        //}




        public async Task<ResponseDto> LoginUser(LogingUserDto loginModel)
        {
            // Find the user by username
            //var user = await _userManager.FindByNameAsync(loginModel.UserName);
            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                // Generate claims for the user
                var authClaims = new List<Claim>
                {
                    // new Claim(ClaimTypes.Name, user.UserName),
                  new Claim(ClaimTypes.Email, user.Email),
              
                  new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

                };

                // Add roles as claims
                var userRoles = await _userManager.GetRolesAsync(user);
                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                // Generate the JWT token
                var jwtToken = _tokenService.GetToken(authClaims);

                // Return the token and expiration details in a ResponseDto
                return new ResponseDto
                {
                    //Status = "Success",
                    //Message = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    Status = "Success",
                    Message = "Login successful",
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    Expiration = jwtToken.ValidTo
                };
            }

            // If the user is not found or password is incorrect, return an error response
            return new ResponseDto
            {
                Status = "Error",
                Message = "Invalid user Email or password, Please! Check Email and Password"
            };
        }

        //// Token generation method
        //private JwtSecurityToken GetToken(List<Claim> authClaims)
        //{
        //    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        //    return new JwtSecurityToken(
        //        issuer: _configuration["JWT:ValidIssuer"],
        //        audience: _configuration["JWT:ValidAudience"],
        //        expires: DateTime.Now.AddHours(3),
        //        claims: authClaims,
        //        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        //    );
        //}

        
    }
}
