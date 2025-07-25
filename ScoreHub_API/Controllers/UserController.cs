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
    public async Task<IActionResult> GetUserByEmail(string email)
    {
        var user = await _usersService.GetUserByEmailAsync(email);
        return Ok(user);
    }
    [HttpPost("/register")]
    public async Task<IActionResult> Register(RegisterUserRequest request)
    {
        var user = new User()
        {
            Email = request.Email,
            Name = request.Name,
            AssistantData = request.Role != Role.Assistant ? null : new()
            {
                Team = new Team()
            },
            TeacherData = request.Role != Role.Teacher ? null : new(),
            StudentData = request.Role != Role.Student ? null : new(),
            GroupNumber = request.GroupNumber,
            PasswordHash = request.Password,
            Role = request.Role
        };
        await _usersService.RegisterUser(user);
        return Ok();
    }
}