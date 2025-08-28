using ScoreHub_Contracts.Users;
using ScoreHub_Infrastructure;

namespace ScoreHub_Application.Users.Features;

public record RegisterCommand(RegisterUserDto Dto) : ICommand;