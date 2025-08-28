using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScoreHub_Application.Services;
using ScoreHub_Application.Users.Features;
using ScoreHub_Application.Users.Features.Login;
using ScoreHub_Contracts.Users;
using ScoreHub_Domain.Entities;
using ScoreHub_Domain.Enums;
using ScoreHub_Domain.Repositories.Features.GetAllUsers;
using ScoreHub_Domain.Repositories.Features.GetWithFilters;
using ScoreHub_Infrastructure;

namespace ScoreHub_Backend.Controllers;

[ApiController]
public class UserController : Controller
{

    [HttpGet("/user/{email}")]
    [Authorize]
    public async Task<IActionResult> GetByEmail(
        string email, 
        [FromServices] IQueryHandler<UserDto,GetUsersByEmailOrIdQuery> queryHandler)
    {
        var query = new GetUsersByEmailOrIdQuery(Email: email);
        var user = await queryHandler.Handle(query);
        return Ok(user);
    }
    
    [HttpGet("/user/{userId:guid}")]
    [Authorize]
    public async Task<IActionResult> GetUserById(
        Guid userId,
        [FromServices] IQueryHandler<UserDto,GetUsersByEmailOrIdQuery> queryHandler)
    {
        var query = new GetUsersByEmailOrIdQuery(Id: userId);
        var user = await queryHandler.Handle(query);
        return Ok(user);
    }
    
    [HttpGet("/users")]
    [Authorize]
    public async Task<IActionResult> GetAllUsers([FromServices] IQueryHandler<UserDto,GetAllUsersQuery> queryHandler)
    {
        var users = await queryHandler.Handle(new GetAllUsersQuery());
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
    public async Task<IActionResult> VerifyTgAuth(
        string userId,
        [FromServices] IQueryHandler<UserDto,GetUsersByEmailOrIdQuery> queryHandler,
        [FromServices] TelegramService telegramService)
    {
        var user = await queryHandler.Handle(new GetUsersByEmailOrIdQuery(Guid.Parse(userId)));
        if (user == null)
        {
            return NotFound();
        }
        
        return Ok(await telegramService.GetTgToken(Guid.Parse(userId)));
    }
    
    [HttpPost("/register")]
    public async Task<IActionResult> Register(
        RegisterUserDto dto, 
        [FromServices] ICommandHandler<RegisterCommand> commandHandler)
    {
        var command = new RegisterCommand(dto);
        await commandHandler.Handle(command);
        return Ok();
    }

    [HttpPost("/login")]
    public async Task<IActionResult> Login(
        LoginUserDto dto,
        [FromServices] ICommandHandler<string, LoginCommand> commandHandler)
    {
        var command = new LoginCommand(dto);
        var token = await commandHandler.Handle(command);
        HttpContext.Response.Cookies.Append("tmp", token);
        return Ok();
    }

    [HttpPut("student/{userId:guid}/new-score/{subjectName}/{score:int}")]
    public async Task<IActionResult> ChangeScore(
        Guid userId, int score, string subjectName, 
        [FromServices] ICommandHandler<ChangeStudentScoreCommand> commandHandler)
    {
        var command = new ChangeStudentScoreCommand(userId, score,subjectName);
        await commandHandler.Handle(command);
        return Ok();
    }
}