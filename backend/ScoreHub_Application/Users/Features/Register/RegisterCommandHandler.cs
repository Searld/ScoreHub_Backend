using ScoreHub_Application.Abstractions;
using ScoreHub_Domain.Entities;

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

        var student = new Student()
        {
            Email = command.Dto.Email,
            Name = command.Dto.Name,
            PasswordHash = hashedPassword,
            Surname = command.Dto.Surname,
            Patronymic = command.Dto.Patronymic
        };

        await _studentRepository.AddAsync(student);
    }
}