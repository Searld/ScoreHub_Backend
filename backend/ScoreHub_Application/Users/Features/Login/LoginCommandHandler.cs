using Microsoft.EntityFrameworkCore;
using ScoreHub_Application.Abstractions;

namespace ScoreHub_Application.Users.Features.Login;

public class LoginCommandHandler : ICommandHandler<string, LoginCommand>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IStudentReadDbContext _readDbContext;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;

    public LoginCommandHandler(
        IStudentReadDbContext readDbContext, 
        IPasswordHasher passwordHasher, 
        IJwtProvider jwtProvider)
    {
        _readDbContext = readDbContext;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
    }
    public async Task<string> Handle(LoginCommand command)
    {
        var student = await _readDbContext.ReadStudents.FirstOrDefaultAsync(u=>u.Email == command.Dto.Email);

        if (student == null)
        {
            throw new Exception("User not found");
        }

        if (!_passwordHasher.Verify(student.PasswordHash, command.Dto.Password))
        {
            throw new Exception("Failed to login");
        }

        var token = _jwtProvider.GenerateToken(student);
        return token;
    }
}