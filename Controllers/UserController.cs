using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Online_Bookstore.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Online_Bookstore.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController(IConfiguration configuration, UserManager<User> userManager) : ControllerBase
    {
        private readonly IConfiguration _configuration; // To get congitation from app.json
        private readonly UserManager<User> _userManager; // user manager services have login register that's why I don't need a repo. for it
        
        public UserController(IConfiguration configuration, UserManager<User> userManager) { 
            _configuration = configuration;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("")]
        [Authorize]
        public IActionResult GetUsers()
        {
            IEnumerable<User> users = _userManager.Users;
            return Ok(users);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                var token = GenerateJwtToken(user);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }


        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(string username, string email, string password)
        {
            User newUser = new()
            {
                UserName = username,
                Email = email,
            };

            var result = await _userManager.CreateAsync(newUser, password);
            
            if (!result.Succeeded)
            {
                return Ok(result.Errors);
            }

            return Ok();
        }

        private string GenerateJwtToken(User user)
        {
            if (user.UserName == null)
            {
                throw new ArgumentNullException(user.UserName);
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? throw new ArgumentNullException(_configuration["Jwt:Key"])));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            if (double.TryParse(_configuration["Jwt:DurationInMinutes"], out double expires))
            {
                throw new Exception();
            }

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(expires),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
