using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using product_web_api.Models;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace product_web_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] Login? user)
    {
        if (user is null) return BadRequest("Invalid client request");
        if (user.Username != "admin" || user.Password != "admin") return Unauthorized();
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var secToken = new JwtSecurityToken(_configuration["JWT:ValidIssuer"],
            _configuration["JWT:ValidIssuer"],
            null,
            expires: DateTime.Now.AddMinutes(10),
            signingCredentials: credentials);

        var token = new JwtSecurityTokenHandler().WriteToken(secToken);

        return Ok(new JwtTokenResponse { Token = token });
    }
}