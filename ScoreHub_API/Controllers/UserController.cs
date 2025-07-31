using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScoreHub_Application.Services;
using ScoreHub_Contracts.Users;
using ScoreHub_Domain.Entities;
using ScoreHub_Domain.Enums;

namespace ScoreHub_Backend.Controllers;

[ApiController]
public class UserController : Controller
{
    private readonly UsersService _usersService;

    public UserController(UsersService usersService)
    {
        _usersService = usersService;
    }
    
    [HttpGet("/user/{email}")]
    [Authorize]
    public async Task<IActionResult> GetUserByEmail(string email)
    {
        //var user = await _usersService.GetUserByEmailAsync(email);
        return Ok();
    }
    
    [HttpGet("/user/{userId:guid}")]
    [Authorize]
    public async Task<IActionResult> GetUserByID(Guid userId)
    {
        var user = await _usersService.GetUserByID(userId);
        return Ok(user);
    }
    
    [HttpGet("/teacher")]
    [Authorize]
    public async Task<IActionResult> GetTeacherById()
    {
        var user = await _usersService
            .GetTeacherByIdAsync(
                Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value));
        return Ok(user);
    }
    
    [HttpGet("/users")]
    [Authorize]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _usersService.GetAllUsers();
        return Ok(users);
    }
    
    [HttpGet("/generate-tg-url")]
    [Authorize]
    public async Task<IActionResult> GenerateTgUrl()
    {
        var userId = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value);
        var link = $"https://t.me/scorehub_bot?start={userId}";
        return Ok(link);
    }
    
    [HttpGet("/verify-tg/{userId}")]
    public async Task<IActionResult> VerifyTgAuth(string userId)
    {
        if (!await _usersService.UserExists(Guid.Parse(userId)))
        {
            return NotFound();
        }
        
        return Ok(await _usersService.GetTgToken(Guid.Parse(userId)));
    }
    
    [HttpPost("/register")]
    public async Task<IActionResult> Register(RegisterUserRequest request)
    {
        await _usersService.RegisterUser(request);
        return Ok();
    }

    [HttpPost("/login")]
    public async Task<IActionResult> Login(LoginUserRequest request)
    {
        var token = await _usersService.Login(request.Email, request.Password);
        HttpContext.Response.Cookies.Append("tmp", token);
        return Ok();
    }

    
}