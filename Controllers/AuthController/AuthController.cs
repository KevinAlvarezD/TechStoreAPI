using Microsoft.AspNetCore.Mvc;
using TechStore.Helpers;
using TechStoreAPI.DTOs.Request;
using TechStoreAPI.Services;

namespace TechStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserServices _userService;
        private readonly IConfiguration _configuration;

        public AuthController(UserServices userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDTO loginRequest)
        {
            var secretKey = _configuration["Jwt:Key"];
            
            var token = await _userService.Login(loginRequest.Email, loginRequest.Password, secretKey);

            if (token == null)
            {
                return Unauthorized("Credenciales incorrectas.");
            }

            return Ok(new { token });
        }
    }
}
