using ScoreHub_Application.Abstractions;
using LessonMkn.Enums;

namespace ScoreHub_Application.Users.Features.Register;

public class RegisterCommandHandler : ICommandHandler<RegisterCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterCommandHandler(
        IUserRepository userRepository, 
        IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }
    
    public async Task Handle(RegisterCommand command)
    {
        var hashedPassword = _passwordHasher.Generate(command.Dto.Password);
        
        
        //await _userRepository.AddAsync(user);
    }
}