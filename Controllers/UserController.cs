using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using UserManagementApi.Interfaces;
using UserManagementApi.Models;

namespace UserManagementApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Get Users Method
        /// </summary>
        /// <returns></returns>

        [Route("Get")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                var users = await _userRepository.GetUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [Route("GetById")]
        [HttpGet]
        public async Task<ActionResult<User>> GetUserById(Guid id)
        {
            try
            {
                var user = await _userRepository.GetUserById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("UserAuthentication")]
        [HttpPost]
        public async Task<ActionResult<User>> UserAuthentication(string email, string password)
        {
            try
            {
                var user = await _userRepository.UserAuthentication(email, password);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Route("Post")]
        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            try
            {
                var result = await _userRepository.PostUser(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
