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
        var user = await _usersService.GetUserByEmailAsync(email);
        return Ok(user);
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

    [HttpGet("/users")]
    [Authorize]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _usersService.GetAllUsers();
        return Ok(users);
    }
}