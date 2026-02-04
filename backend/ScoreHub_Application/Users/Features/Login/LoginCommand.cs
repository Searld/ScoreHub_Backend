
using ScoreHub_Application.Abstractions;
using ScoreHub_Contracts.Users;

namespace ScoreHub_Application.Users.Features.Login;

public record LoginCommand(LoginUserDto Dto) : ICommand;