using ScoreHub_Application.Abstractions;

namespace ScoreHub_Application.Users.Features.ChangeStudentScore;

public class ChangeStudentScoreCommandHandler : ICommandHandler<ChangeStudentScoreCommand>
{
    private readonly IUserRepository _userRepository;

    public ChangeStudentScoreCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task Handle(ChangeStudentScoreCommand command)
    {
        await _userRepository.ChangeStudentScoreAsync(command.Id, command.NewScore,command.SubjectName);
    }
}