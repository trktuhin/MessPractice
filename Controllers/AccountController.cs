using Mess.Models;
using Mess.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Mess.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterResource model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var user = new ApplicationUser
                {
                    FirstName=model.FirstName,
                    LastName=model.LastName,
                    Email=model.Email,
                    DateCreated=DateTime.Now,
                    UserName=model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var userInDb=GetUser(user.Email);
                    // await _signInManager.SignInAsync(user, false);
                    var authData = new AuthDataResource
                    {
                        Token = await GenerateJwtToken(userInDb),
                        UserId = userInDb.Id,
                        ExpireTime = DateTime.Now.AddHours(Convert.ToDouble(_configuration["JwtExpireHours"])),
                        FirstName=userInDb.FirstName,
                        LastName=userInDb.LastName
                    };

                    return Ok(authData);
                }
                AddErrors(result);

            }
            catch (Exception e)
            {
                return BadRequest("Somwthing Gone Wrong");
            }

            return BadRequest();

        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginResource model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

                if (!result.Succeeded) return BadRequest("Wrong username or password");

                var user = GetUser(model.UserName);

                var authData = new AuthDataResource
                {
                    Token = await GenerateJwtToken(user),
                    UserId = user.Id,
                    ExpireTime = DateTime.Now.AddHours(Convert.ToDouble(_configuration["JwtExpireHours"])),
                    FirstName=user.FirstName,
                    LastName=user.LastName
                };

                return Ok(authData);
            }
            catch (Exception e)
            {
                // ignored
            }

            return BadRequest("Somthing gone wrong");
        }

        private ApplicationUser GetUser(string username){
            return _userManager.Users.SingleOrDefault(x => x.UserName == username);
        }
        private async Task<string> GenerateJwtToken(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.FirstName ?? ""),
                new Claim("currency","taka") 
            };

            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Any())
                claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddHours(Convert.ToDouble(_configuration["JwtExpireHours"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}