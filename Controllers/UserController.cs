using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Bookstore.Models;
using Online_Bookstore.Services;

namespace Online_Bookstore.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository) { 
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("")]
        public IActionResult getUsers()
        {
            IEnumerable<User> users = _userRepository.GetUsers();
            return Ok(users);
        }
    }
}
