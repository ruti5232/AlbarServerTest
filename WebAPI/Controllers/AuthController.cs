using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login request)
        {
            try
            {
                var token = await _authService.AuthenticateAsync(request.Username, request.Password);
                return Ok(new { Token = token });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }






        //[HttpPost("login")]
        //public IActionResult Login([FromBody] UserDTO user)
        //{
        //    if (user.UserName == "admin" && user.Password == "password")
        //    {
        //        var token = GenerateJwtToken(user.UserName);
        //        return Ok(new { token });
        //    }
        //    return Unauthorized();
        //}

        //private string GenerateJwtToken(string username)
        //{
        //    var claims = new[]
        //    {
        //    new Claim(JwtRegisteredClaimNames.Sub, username),
        //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //};

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secret_key"));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(
        //        issuer: "yourdomain.com",
        //        audience: "yourdomain.com",
        //        claims: claims,
        //        expires: DateTime.Now.AddMinutes(30),
        //        signingCredentials: creds);

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
    }
    public class Login
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
