using DiplomApi.Data;
using DiplomApi.DTO;
using DiplomApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiplomApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    public DiplomContext Context {get; set; }
    
    public UsersController(DiplomContext context)
    {
        Context = context;
    }
    
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<UserDTO>>> Get()
    {
        var users = await Context
            .Users
            .Select(user => new UserDTO()
            {
                Username = user.Username,
                Id = user.Id,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            })
            .ToListAsync();
        
        return Ok(users);
    }
    
    [HttpPost]
    public async Task<ActionResult<UserDTO>> Post(User user)
    {
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        
        await Context.Users.AddAsync(user);
        await Context.SaveChangesAsync();
        return Ok(new UserDTO()
        {
            Username = user.Username,
            Id = user.Id,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        });
    }
}
