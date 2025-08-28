using ScoreHub_Domain.Entities;
using ScoreHub_Domain.Enums;
using ScoreHub_Domain.Repositories;
using ScoreHub_Infrastructure;

namespace ScoreHub_Application.Users.Features;

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

        User user = new object() switch
        {
            Role.Assistant => new Assistant()
            {
                Email = command.Dto.Email,
                PasswordHash = hashedPassword,
                Id = Guid.NewGuid(),
                Role = Role.Assistant,
                Name = command.Dto.Name
            },
            Role.Student => new Student()
            {
                Email = command.Dto.Email,
                PasswordHash = hashedPassword,
                Id = Guid.NewGuid(),
                Role = Role.Student,
                Name = command.Dto.Name,
                GroupNumber = command.Dto.GroupNumber
            },
            Role.Teacher => new Teacher()
            {
                Email = command.Dto.Email,
                PasswordHash = hashedPassword,
                Id = Guid.NewGuid(),
                Role = Role.Teacher,
                Name = command.Dto.Name
            },
        };
        
        await _userRepository.AddAsync(user);
    }
}