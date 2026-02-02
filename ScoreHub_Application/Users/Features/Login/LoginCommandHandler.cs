using Microsoft.EntityFrameworkCore;
using ScoreHub_Application.Abstractions;

namespace ScoreHub_Application.Users.Features.Login;

public class LoginCommandHandler : ICommandHandler<string, LoginCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserReadDbContext _readDbContext;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;

    public LoginCommandHandler(
        IUserReadDbContext readDbContext, 
        IPasswordHasher passwordHasher, 
        IJwtProvider jwtProvider)
    {
        _readDbContext = readDbContext;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
    }
    public async Task<string> Handle(LoginCommand command)
    {
        var user = await _readDbContext.ReadUsers.FirstOrDefaultAsync(u=>u.Email == command.Dto.Email);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        if (!_passwordHasher.Verify(user.PasswordHash, command.Dto.Password))
        {
            throw new Exception("Failed to login");
        }

        var token = _jwtProvider.GenerateToken(user);
        return token;
    }
}