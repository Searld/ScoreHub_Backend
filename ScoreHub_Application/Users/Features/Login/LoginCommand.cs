
using ScoreHub_Contracts.Users;
using ScoreHub_Infrastructure;

namespace ScoreHub_Application.Users.Features.Login;

public record LoginCommand(LoginUserDto Dto) : ICommand;