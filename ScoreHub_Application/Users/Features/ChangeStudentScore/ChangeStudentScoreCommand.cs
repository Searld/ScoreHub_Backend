using ScoreHub_Contracts.Users;
using ScoreHub_Infrastructure;

namespace ScoreHub_Application.Users.Features.Login;

public record ChangeStudentScoreCommand(Guid Id, int NewScore, string SubjectName) : ICommand;