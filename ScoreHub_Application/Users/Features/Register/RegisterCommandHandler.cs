using ScoreHub_Application.Abstractions;

namespace ScoreHub_Application.Users.Features.Register;

public class RegisterCommandHandler : ICommandHandler<RegisterCommand>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterCommandHandler(
        IStudentRepository studentRepository, 
        IPasswordHasher passwordHasher)
    {
        _studentRepository = studentRepository;
        _passwordHasher = passwordHasher;
    }
    
    public async Task Handle(RegisterCommand command)
    {
        var hashedPassword = _passwordHasher.Generate(command.Dto.Password);
        
        
        //await _userRepository.AddAsync(user);
    }
}