using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TechStoreAPI.DTOs.Request;
using TechStoreAPI.Services;

namespace TechStoreAPI.Controllers.AuthController
{
    [ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserServices _userService;

    public AuthController(UserServices userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDTO login)
    {
        if (login == null)
        {
            return BadRequest("Invalid login request");
        }

        var user = _userService.GetUserByEmail(login.Email);
        if (user == null)
        {
            return Unauthorized("User not found");
        }

        if (!BCrypt.Net.BCrypt.Verify(login.Password, user.Password))
        {
            return Unauthorized("Invalid password");
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Username),
        };

        var token = new JwtSecurityToken(
            issuer: Environment.GetEnvironmentVariable("JWT_ISSUER"),
            audience: Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET_KEY"))),
                SecurityAlgorithms.HmacSha256
            )
        );

        return Ok(new
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            user.Email
        });
    }
}

}