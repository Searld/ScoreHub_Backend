using ScoreHub_Application.Abstractions;
using ScoreHub_Contracts.Users;

namespace ScoreHub_Application.Users.Features.Register;

public record RegisterCommand(RegisterUserDto Dto) : ICommand;