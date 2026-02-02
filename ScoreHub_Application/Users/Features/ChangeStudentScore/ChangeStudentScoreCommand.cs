using ScoreHub_Application.Abstractions;

namespace ScoreHub_Application.Users.Features.ChangeStudentScore;

public record ChangeStudentScoreCommand(Guid Id, int NewScore, string SubjectName) : ICommand;