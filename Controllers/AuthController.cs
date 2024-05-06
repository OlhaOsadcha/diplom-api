using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DiplomApi.Data;
using DiplomApi.DTO;
using DiplomApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DiplomApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController: ControllerBase
{
    public IConfiguration Configuration { get; set; }
    public DiplomContext Context {get; set; }
    
    public AuthController(IConfiguration configuration, DiplomContext context)
    {
        Configuration = configuration;
        Context = context;
    }
    
    string CreateToken(User user)
    {
        var section = Configuration.GetSection("JWT");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(section.GetValue<string>("SecurityKey")));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var issuer = section.GetValue<string>("Issuer");
        var audience = section.GetValue<string>("Audience");
        var jwtValidity = DateTime.Now.AddHours(section.GetValue<int>("ValidityHours"));

        var token = new JwtSecurityToken(
            issuer, 
            audience, 
            new List<Claim>()
            {
                // new Claim("id", user.Id.ToString()),
                new Claim("username", user.Username),
            },
            expires: jwtValidity, 
            signingCredentials: creds
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    [HttpPost("/Login")]
    public async Task<ActionResult<string>> Login(LoginUserDTO user)
    {
        var foundUser = await Context
            .Users
            .Where(u => u.Username == user.Username)
            .FirstOrDefaultAsync();
        
        if (foundUser == null)
        {
            return NotFound(new {message = "Not Found"});
        }
        
        var valid = BCrypt.Net.BCrypt.Verify(user.Password, foundUser.Password);

        if (valid)
        {
            return Ok(new {token = CreateToken(foundUser)});
        }

        return BadRequest(new {message = "Bad Password" });
    }
}